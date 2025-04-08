using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using VideoToGifConverter.Model;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing the list of MP4 videos in the Video to GIF Converter application.
    /// Holds an observable collection of <see cref="Mp4Object"/> items representing MP4 files.
    /// This allows dynamic updates to the UI when MP4 objects are added, removed, or modified.
    /// </summary>
    public partial class VideoListVM : ObservableObject
    {
        /// <summary>
        /// Gets or sets the observable collection of <see cref="Mp4Object"/> representing MP4 video files.
        /// Changes to this collection will automatically notify the UI for data binding updates.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Mp4Object> _mp4Objects = new ObservableCollection<Mp4Object>();

        /// <summary>
        /// Controls the visibility of the Grid in the UI.
        /// When set to <see cref="Visibility.Visible"/>, the Grid is displayed.
        /// When set to <see cref="Visibility.Collapsed"/>, the Grid is Collapsed.
        /// This property is bound to the UI to dynamically show or hide elements as needed.
        /// </summary>
        [ObservableProperty]
        private Visibility _visibility = Visibility.Collapsed;
    }
}
