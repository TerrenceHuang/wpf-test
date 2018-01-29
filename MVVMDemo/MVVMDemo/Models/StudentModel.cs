using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models {

    class StudentModel {

    }

    public class Student : INotifyPropertyChanged {

        #region Properties
        public string FirstName {

            get { return this.firstName; }
            set {

                if (this.firstName != value) {

                    this.firstName = value;
                    this.RaisePropertyChanged("FirstName");
                    this.RaisePropertyChanged("FullName");
                }
            }
        }

        public string LastName {

            get { return this.lastName; }
            set {

                if (this.lastName != value) {

                    this.lastName = value;
                    this.RaisePropertyChanged("LastName");
                    this.RaisePropertyChanged("FullName");
                }
            }
        }

        public string FullName {
            get { return this.firstName + " " + this.lastName; }
        }
        #endregion

        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;

        string firstName;
        string lastName;
        #endregion

        #region Methods

        void RaisePropertyChanged(string property) {

            if (this.PropertyChanged != null) {

                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
