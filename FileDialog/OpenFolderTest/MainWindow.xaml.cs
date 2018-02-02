﻿using Microsoft.Win32;
using System.Windows;

namespace OpenFolderTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void BtnOpenFile_Click(object sender, RoutedEventArgs e) {

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
            }
        }
    }
}