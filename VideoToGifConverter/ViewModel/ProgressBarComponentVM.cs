using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing the progress bar component in the Video to GIF converter application.
    /// Handles progress updates, visibility, and status messages.
    /// </summary>
    public class ProgressBarComponentVM : ObservableObject
    {
        // Constants
        private readonly string PROGRESS_TEXT = "Progressing...";
        private readonly string PERCENTAGE_SYMBOL = "%";

        #region Properties

        private bool _isGridVisible = false;
        public bool IsGridVisible
        {
            get => _isGridVisible;
            set => SetProperty(ref _isGridVisible, value);
        }

        private Visibility _visibility = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the visibility of the progress bar component.
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                SetProperty(ref _visibility, value, nameof(Visibility));
                OnPropertyChanged(nameof(Visibility));
            }
        }

        private string _progressText = string.Empty;

        /// <summary>
        /// Gets or sets the progress text displayed on the progress bar.
        /// </summary>
        public string ProgressText
        {
            get => _progressText;
            set => SetProperty(ref _progressText, value, nameof(ProgressText));
        }

        private double _maxValue = 0;

        /// <summary>
        /// Gets or sets the maximum value for the progress bar.
        /// </summary>
        public double MaximumValue
        {
            get => _maxValue;
            set
            {
                SetProperty(ref _maxValue, value);
                OnPropertyChanged(nameof(ProgressBarComponentVM));
            }
        }

        private double _currentValue = 0;

        /// <summary>
        /// Gets or sets the current value of the progress bar.
        /// </summary>
        public double CurrentValue
        {
            get => _currentValue;
            set
            {
                SetProperty(ref _currentValue, value, nameof(CurrentValue));
            }
        }

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
