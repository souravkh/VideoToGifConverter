﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Windows;
using System.Windows.Input;
using VideoToGifConverter.Helper;
using VideoToGifConverter.Model;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for the Main Window in the Video to GIF Converter application.
    /// Manages the input/output folder locations, updates the list of MP4 files, 
    /// and handles video-to-GIF conversion logic.
    /// </summary>
    [ObservableObject]
    public partial class MainWindowVM
    {
        private VideoListVM _videoListVM=new VideoListVM();
        private Mp4ToGifHelper _mp4ToGifHelper;
        private readonly string[] SUPPORTED_FORMATS = new[] { "*.mp4", "*.avi", "*.mov", "*.webm" };

        /// <summary>
        /// ViewModel for managing the progress bar during conversion.
        /// </summary>
        [ObservableProperty]
        private ProgressBarComponentVM _progressBarComponentVM = new ProgressBarComponentVM();

        /// <summary>
        /// ViewModel property that determines the visibility of the Convert button in the UI.
        /// When set to <c>true</c>, the button will be visible; when set to <c>false</c>, it will be hidden.
        /// This property supports automatic UI updates through data binding.
        /// </summary>
        [ObservableProperty]
        private bool _isConvertBottonVisible = false;

        /// <summary>
        /// Gets or sets the ViewModel for the list of MP4 videos.
        /// This list is dynamically updated based on the selected input folder.
        /// </summary>
        public VideoListVM VideoListVM
        {
            get => _videoListVM;
            set => SetProperty(ref _videoListVM, value);
        }

        /// <summary>
        /// ViewModel for selecting the input folder containing MP4 files.
        /// </summary>
        [ObservableProperty]
        private FolderComponentVM _inputVm;

        /// <summary>
        /// ViewModel for selecting the output folder where GIFs will be saved.
        /// </summary>
        [ObservableProperty]
        private FolderComponentVM _outputVm;

        /// <summary>
        /// Command for triggering the video-to-GIF conversion process.
        /// </summary>
        public ICommand ConvertCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVM"/> class.
        /// Sets up the input/output folder ViewModels and attaches property change handlers.
        /// </summary>
        public MainWindowVM()
        {
            _mp4ToGifHelper = new Mp4ToGifHelper();
            InputVm = new FolderComponentVM("Browse Input Location", "Input Folder");
            InputVm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(FolderComponentVM.Location))
                {
                    UpdateMp4List();
                    UpdateOutputLocation();
                }
            };

            OutputVm = new FolderComponentVM("Browse Output Location", "Output Folder");
            ConvertCommand = new RelayCommand(UpdateVideosToGif);
        }

        /// <summary>
        /// Retrieves a list of all MP4 files from the specified directory.
        /// </summary>
        /// <param name="dir">The directory path to search for MP4 files.</param>
        /// <returns>A list of MP4 file paths found in the directory.</returns>
        public List<string> GetMP4FilesFromDir(string dir)
        {
            return SUPPORTED_FORMATS?.
                SelectMany(format => Directory.GetFiles(dir,
                format, 
                SearchOption.AllDirectories))?
                .ToList()
                ??new List<string>();
        }

        /// <summary>
        /// Updates the MP4 file list based on the current input folder location.
        /// Creates a new VideoListVM with the updated MP4 objects.
        /// </summary>
        public void UpdateMp4List()
        {
            
            if (!string.IsNullOrEmpty(_inputVm?.Location))
            {
                var mp4List = GetMP4FilesFromDir(_inputVm?.Location);
                if (mp4List?.Count > 0)
                {
                    List<Mp4Object> mp4Objects = new List<Mp4Object>();
                    foreach (var file in mp4List)
                    {
                        mp4Objects.Add(new Mp4Object(Path.GetFileNameWithoutExtension(file), file));
                    }

                    VideoListVM = new VideoListVM
                    {
                        Mp4Objects = new System.Collections.ObjectModel.ObservableCollection<Mp4Object>(mp4Objects)
                    };
                    VideoListVM.Visibility = Visibility.Visible;
                    IsConvertBottonVisible = true;
                    OnPropertyChanged(nameof(VideoListVM));
                }
            }
            else
            {
                if (VideoListVM != null)
                {
                    VideoListVM.Visibility = Visibility.Collapsed;
                    OnPropertyChanged(nameof(VideoListVM));
                }
                IsConvertBottonVisible=false;
            }
        }

        /// <summary>
        /// Updates the output folder location based on the current input folder.
        /// Creates an output folder named "Output" inside the input folder.
        /// </summary>
        public void UpdateOutputLocation()
        {
            string inputLocation = _inputVm?.Location ?? string.Empty;
            if (!string.IsNullOrEmpty(inputLocation))
            {
                const string OUTPUT = "Output";
                string outPutLocation = Path.Combine(inputLocation, OUTPUT);
                OutputVm.Location = outPutLocation;
            }
        }

        /// <summary>
        /// Converts selected MP4 videos to GIF format.
        /// Updates the progress bar during the conversion process.
        /// </summary>
        public void UpdateVideosToGif()
        {
            try
            {
                string outputLocation = OutputVm?.Location ?? string.Empty;
                if (!string.IsNullOrEmpty(outputLocation))
                {
                    CheckCreateOutputDir(outputLocation);

                    var selectedMp4Objects = VideoListVM?.Mp4Objects
                        .Where(s => s.IsChecked)
                        .ToList();

                    if (selectedMp4Objects?.Count > 0)
                    {
                        Task.Run(() =>
                        {
                            IsConvertBottonVisible = false;
                            ProgressBarComponentVM.MaximumValue = selectedMp4Objects.Count;
                            ProgressBarComponentVM.IsGridVisible = true;

                            foreach (var mp4Object in selectedMp4Objects)
                            {
                                if (_mp4ToGifHelper.ConvertVideoToGIf(mp4Object.FileName,
                                    mp4Object.FilePath,
                                    outputLocation))
                                {
                                    ProgressBarComponentVM.UpdateProgress();
                                }
                            }
                            ProgressBarComponentVM.UpdateSuccessfullMessage();
                            ProgressBarComponentVM.ProgressText = string.Empty;
                            ProgressBarComponentVM.IsGridVisible = false;
                            ProgressBarComponentVM.MaximumValue = 0;
                            IsConvertBottonVisible = true;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Resets the properties of child ViewModels to their default states.
        /// This includes clearing progress text, hiding the progress grid,
        /// resetting the maximum value, hiding the video list, and clearing 
        /// input/output locations.
        /// </summary>
        public void ResetChildViewModels()
        {
            // Clear the progress text in the ProgressBar ViewModel
            ProgressBarComponentVM.ProgressText = string.Empty;

            // Hide the progress grid
            ProgressBarComponentVM.IsGridVisible = false;

            // Reset the maximum value of the progress bar to zero
            ProgressBarComponentVM.MaximumValue = 0;

            // Collapse the visibility of the Video List ViewModel
            VideoListVM.Visibility = Visibility.Collapsed;

            // Clear the location in the Input ViewModel
            InputVm.Location = string.Empty;

            // Clear the location in the Output ViewModel
            OutputVm.Location = string.Empty;
        }


        /// <summary>
        /// Checks if the output directory exists; if not, it creates the directory.
        /// </summary>
        /// <param name="dir">The directory path to check and create if necessary.</param>
        public void CheckCreateOutputDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
