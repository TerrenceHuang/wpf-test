using Service.Utilities;
using System;
using System.Collections.Generic;
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

namespace Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Timer timer;

        public MainWindow() {

            InitializeComponent();

            this.timer = new Timer();
            this.timer.changeTextDelegate += changeLabelText;
            this.timer.start();
        }

        public void changeLabelText(string text) {

            this.label.Content = text;
            Console.WriteLine(text);
        }
    }
}
