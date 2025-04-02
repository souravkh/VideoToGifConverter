using CommunityToolkit.Mvvm.ComponentModel;

namespace VideoToGifConverter.Model
{
    /// <summary>
    /// Represents an MP4 file with properties such as file name, file path, and selection status.
    /// Implements <see cref="ObservableObject"/> to support data binding in MVVM architecture.
    /// </summary>
    public class Mp4Object : ObservableObject
    {
        private bool _isChecked = true;

        /// <summary>
        /// Gets or sets a value indicating whether the MP4 file is selected.
        /// </summary>
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                SetProperty(ref _isChecked, value);
                OnPropertyChanged(nameof(Mp4Object));
            }
        }

        private string _fileName = string.Empty;

        /// <summary>
        /// Gets or sets the name of the MP4 file (without extension).
        /// </summary>
        public string FileName
        {
            get => _fileName;
            set
            {
                SetProperty(ref _fileName, value);
                OnPropertyChanged(nameof(Mp4Object));
            }
        }

        private string _filePath = string.Empty;

        /// <summary>
        /// Gets or sets the full path to the MP4 file.
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                SetProperty(ref _filePath, value);
                OnPropertyChanged(nameof(Mp4Object));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mp4Object"/> class with the specified file name and path.
        /// </summary>
        /// <param name="fileName">The name of the MP4 file (without extension).</param>
        /// <param name="filePath">The full path to the MP4 file.</param>
        public Mp4Object(string fileName, string filePath)
        {
            FilePath = filePath;
            FileName = fileName;
        }
    }
}
