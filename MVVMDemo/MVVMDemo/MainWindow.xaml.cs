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

namespace MVVMDemo {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Practice following this website
    /// https://www.tutorialspoint.com/mvvm/mvvm_first_application.htm
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        void StudentViewControl_Loaded(object sender, RoutedEventArgs e) {

            ViewModels.StudentViewModel studentViewModelObject = new ViewModels.StudentViewModel();
            studentViewModelObject.LoadStudents();

            this.StudentViewControl.DataContext = studentViewModelObject;
        }
    }
}
