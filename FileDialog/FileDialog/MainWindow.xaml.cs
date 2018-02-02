using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace SaveFileDialogTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// practice from http://www.wpf-tutorial.com/dialogs/the-savefiledialog/
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void BtnSaveFile_Click(object sender, RoutedEventArgs e) {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            //saveFileDialog.InitialDirectory = @"d:\temp\";
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.AddExtension = false;

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, TxtEditor.Text);
        }
    }
}
