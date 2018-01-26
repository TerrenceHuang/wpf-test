using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWithService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Process process = new Process();
        string startFileName = "Service\\service.exe";

        int lineCount = 0;
        

        public MainWindow() {

            InitializeComponent();

            this.newProcess();
        }

        void newProcess() {

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Environment.CurrentDirectory + '\\' + this.startFileName;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;

            // Tow start ways.
            // 1
            ////Process.Start(processStartInfo);
            // .1
            // 2
            this.process.StartInfo = processStartInfo;
            this.process.OutputDataReceived += this.outputDataReceived;
            this.process.Start();

            // Asynchronously read the standard output of the spawned process.
            // This raises OutputDataReceived events for each line of output.
            this.process.BeginOutputReadLine();
            // .2


        }

        #region Event handlers
        void outputDataReceived(object sender, DataReceivedEventArgs e) {

            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data)) {

                string outputMessage = this.startFileName + " [" + ++this.lineCount + "]: " + e.Data;
                Console.WriteLine(outputMessage);

                // Other thread need use this method to update UI.
                this.Dispatcher.Invoke(() => {

                    this.label.Content += "\n" + outputMessage;
                });
            }
        }

        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            
            // need to check whether mainwindow exist
            this.process.CloseMainWindow();
            this.process.Close();
        }
        #endregion
    }
}
