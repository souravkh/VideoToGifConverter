using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using VideoToGifConverter.Model;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing the list of MP4 videos in the Video to GIF Converter application.
    /// Holds an observable collection of <see cref="Mp4Object"/> items representing MP4 files.
    /// </summary>
    public class VideoListVM : ObservableObject
    {
        private ObservableCollection<Mp4Object> _mp4Objects = new ObservableCollection<Mp4Object>();

        /// <summary>
        /// Gets or sets the observable collection of <see cref="Mp4Object"/> representing MP4 files.
        /// </summary>
        public ObservableCollection<Mp4Object> Mp4Objects
        {
            get => _mp4Objects;
            set
            {
                if (value != null)
                {
                    SetProperty(ref _mp4Objects, value);
                    OnPropertyChanged(nameof(VideoListVM));
                }
            }
        }

    }
}
