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

namespace PosiflexPrinter {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        SveltaController sveltaController;

        public MainWindow() {

            InitializeComponent();
            //PrinterController.PrinterName = @"\\localhost\Posiflex Printer";

            //this.sveltaController = new SveltaController();
            //sveltaController.PrinterName = @"\\localhost\STIMA";
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            //PrinterController.PrintQRCode("Hello");

            StimaPrinterController.PrintTicket();

            //this.sveltaController.PrintData();
        }
    }
}
