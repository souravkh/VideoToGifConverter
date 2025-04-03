using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Windows.Input;

namespace VideoToGifConverter.ViewModel
{
    /// <summary>
    /// ViewModel for managing folder selection and related UI bindings.
    /// Implements the MVVM pattern using CommunityToolkit.Mvvm.
    /// </summary>
    public partial class FolderComponentVM : ObservableObject
    {
        [ObservableProperty] private string _labelText = string.Empty;
        [ObservableProperty] private string _location = string.Empty;

        /// <summary>
        /// Gets or sets the placeholder text displayed when no location is selected.
        /// </summary>
        public string PlaceHolderContent { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderComponentVM"/> class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text displayed when no folder is selected.</param>
        /// <param name="label">The label text displayed alongside the folder picker.</param>
        public FolderComponentVM(string placeholderText, string label)
        {
            PlaceHolderContent = placeholderText;
            LabelText = label;
        }

        /// <summary>
        /// Opens a folder dialog for the user to select a folder.
        /// Updates the <see cref="Location"/> property with the selected folder path.
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
            if (result==true)
            {
                string selectedLoc = openFolderDialog.FolderName ?? string.Empty;
                if (!string.IsNullOrEmpty(selectedLoc))
                {
                    Location = selectedLoc;
                    OnPropertyChanged(nameof(FolderComponentVM));
                }
            }
        }
    }
}
