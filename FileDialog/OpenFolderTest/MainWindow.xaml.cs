using Microsoft.Win32;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace OpenFolderTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void BtnOpenFile_Click(object sender, RoutedEventArgs e) {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Set validate names and check file exits to false otherwise windows will
            // not let you select "Folder Selection."
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            // Always default to Folder Selection.
            openFileDialog.FileName = "Folder Selection.";


            if (openFileDialog.ShowDialog() == true) {
                TxtEditor.Text = openFileDialog.FileName;
            }*/

            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            commonOpenFileDialog.IsFolderPicker = true;
            CommonFileDialogResult result = commonOpenFileDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok) {

                TxtEditor.Text = commonOpenFileDialog.FileName;
            }
        }

        void BtnSaveFile_Click(object sender, RoutedEventArgs e) {


            CommonSaveFileDialog commonSaveFileDialog = new CommonSaveFileDialog();
            commonSaveFileDialog.DefaultFileName = "Script";

            CommonFileDialogResult result = commonSaveFileDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok) {

                TxtEditor.Text = commonSaveFileDialog.FileName;
            }
        }
    }
}
