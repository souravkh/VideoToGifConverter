using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing the progress bar component in the Video to GIF converter application.
    /// Handles progress updates, visibility, and status messages.
    /// </summary>
    public partial class ProgressBarComponentVM : ObservableObject
    {
        // Constants
        private readonly string PROGRESS_TEXT = "Progressing...";
        private readonly string PERCENTAGE_SYMBOL = "%";

        #region Properties
        [ObservableProperty]
        private bool _isGridVisible = false;

        [ObservableProperty]
        private string _progressText = string.Empty;

        [ObservableProperty]
        private double _maximumValue = 0;

        [ObservableProperty]
        private double _currentValue = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the current progress percentage based on the current and maximum values.
        /// </summary>
        /// <returns>The progress percentage rounded to 4 decimal places.</returns>
        private double GetPercentage()
        {
            return Math.Round((CurrentValue / MaximumValue), 4) * 100;
        }

        /// <summary>
        /// Updates the progress text with the current progress percentage.
        /// </summary>
        public void UpdateProgressText()
        {
            ProgressText = PROGRESS_TEXT + GetPercentage() + PERCENTAGE_SYMBOL;
        }

        /// <summary>
        /// Updates the progress bar to display a success message after conversion.
        /// Pauses for 2 seconds to allow the user to see the message.
        /// </summary>
        public void UpdateSuccessfullMessage()
        {
            ProgressText = "Successfully converted Videos to Gif!";
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Increments the current progress value by 1 and updates the progress text.
        /// </summary>
        public void UpdateProgress()
        {
            if (CurrentValue <= MaximumValue)
            {
                CurrentValue += 1;
                UpdateProgressText();
            }
        }

        #endregion
    }
}
