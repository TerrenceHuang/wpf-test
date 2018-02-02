using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace OpenFileDialogTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// practice from http://www.wpf-tutorial.com/dialogs/the-openfiledialog/
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void BtnOpenFile_Click(object sender, RoutedEventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true) {
                TxtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}
