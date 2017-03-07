using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Model
{
    // properties
    public class Student : INotifyPropertyChanged
    {
        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("FullName");
                }
            }
        }
        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set {
                if (lastname != value)
                {
                    lastname = value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                }
            }
        }
        public string FullName
        {
            get
            {
                return firstname + " " + lastname;
            }
        }
        public string Asioid { get; set; }
        //Constructors
        //Methods
        //Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
