using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using VideoToGifConverter.Model;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing the list of MP4 videos in the Video to GIF Converter application.
    /// Holds an observable collection of <see cref="Mp4Object"/> items representing MP4 files.
    /// </summary>
    public partial class VideoListVM : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Mp4Object> _mp4Objects = new ObservableCollection<Mp4Object>();

    }
}
