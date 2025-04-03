using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing folder selection and related UI bindings in the VideoToGifConverter application.
    /// Implements the MVVM pattern using CommunityToolkit.Mvvm for clean separation of concerns.
    /// </summary>
    public partial class FolderComponentVM : ObservableObject
    {
        /// <summary>
        /// Gets or sets the label text displayed next to the folder picker.
        /// </summary>
        [ObservableProperty]
        private string _labelText = string.Empty;

        /// <summary>
        /// Gets or sets the path of the selected folder.
        /// </summary>
        [ObservableProperty]
        private string _location = string.Empty;

        /// <summary>
        /// Gets or sets the placeholder text displayed when no folder is selected.
        /// This helps guide the user to select a folder.
        /// </summary>
        public string PlaceHolderContent { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderComponentVM"/> class with specified placeholder and label.
        /// </summary>
        /// <param name="placeholderText">The placeholder text displayed when no folder is selected.</param>
        /// <param name="label">The label text displayed alongside the folder picker.</param>
        public FolderComponentVM(string placeholderText, string label)
        {
            PlaceHolderContent = placeholderText;
            LabelText = label;
        }

        /// <summary>
        /// Command that opens a folder dialog to allow the user to select a folder.
        /// Updates the <see cref="Location"/> property with the selected folder's path.
        /// </summary>
        [RelayCommand]
        private void BrowserDirectory()
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog
            {
                Multiselect = false,
                ShowHiddenItems = true
            };

            bool? result = openFolderDialog.ShowDialog();
            if (result == true)
            {
                string selectedLoc = openFolderDialog.FolderName ?? string.Empty;
                if (!string.IsNullOrEmpty(selectedLoc))
                {
                    Location = selectedLoc;
                    OnPropertyChanged(nameof(FolderComponentVM)); // Consider changing to OnPropertyChanged(nameof(Location)) for better clarity
                }
            }
        }
    }
}
