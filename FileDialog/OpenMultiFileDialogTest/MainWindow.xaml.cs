using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Shapes;

namespace OpenMultiFileDialogTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void BtnOpenFile_Click(object sender, RoutedEventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true) {

                foreach (string filename in openFileDialog.FileNames)
                    LbFiles.Items.Add(filename);
            }
        }
    }
}
