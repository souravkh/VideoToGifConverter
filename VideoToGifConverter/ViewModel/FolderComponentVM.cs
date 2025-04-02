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
    public class FolderComponentVM : ObservableObject
    {
        private string _labelText = string.Empty;
        private string _location = string.Empty;

        /// <summary>
        /// Gets or sets the label text displayed next to the folder picker.
        /// </summary>
        public string LabelText
        {
            get => _labelText;
            set
            {
                if (value!=null)
                {
                    SetProperty(ref _labelText, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected folder's path.
        /// </summary>
        public string Location
        {
            get => _location;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    SetProperty(ref _location, value);
                    OnPropertyChanged(nameof(FolderComponentVM));
                }
            }
        }

        /// <summary>
        /// Gets or sets the placeholder text displayed when no location is selected.
        /// </summary>
        public string PlaceHolderContent { get; set; } = string.Empty;

        /// <summary>
        /// Command triggered when the user clicks the "Browse" button to select a folder.
        /// </summary>
        public ICommand BrowseCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderComponentVM"/> class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text displayed when no folder is selected.</param>
        /// <param name="label">The label text displayed alongside the folder picker.</param>
        public FolderComponentVM(string placeholderText, string label)
        {
            PlaceHolderContent = placeholderText;
            LabelText = label;
            BrowseCommand = new RelayCommand(BrowserDir);
        }

        /// <summary>
        /// Opens a folder dialog for the user to select a folder.
        /// Updates the <see cref="Location"/> property with the selected folder path.
        /// </summary>
        private void BrowserDir()
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
