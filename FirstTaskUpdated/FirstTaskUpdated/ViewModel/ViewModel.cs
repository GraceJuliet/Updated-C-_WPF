using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstTaskUpdated
{

  
        class ViewModel : INotifyPropertyChanged
        {
            public RelayCommand cmd { get; set; }
           
            public ViewModel()
            {
                cmd = new RelayCommand(Canexecute, CanUse);
              

            }

            private string username;
            private string password;



            public string Name
            {
                get
                {
                    return username;
                }
                set
                {
                    username = value;
                    OnPropertyChanged("Name");
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
            private System.Windows.Visibility showvisibility;
            public System.Windows.Visibility Showvisibility
            {
                get
                {
                    return showvisibility;
                }
                set
                {
                    showvisibility = value;
                    OnPropertyChanged("Showvisibility");
                }
            }
            private System.Windows.Visibility hidevisibility;
            public System.Windows.Visibility Hidevisibility
            {
                get
                {
                    return hidevisibility;
                }
                set
                {
                    hidevisibility = value;
                    OnPropertyChanged("Hidevisibility");
                }
            }
            private System.Windows.Visibility pwd;
            public System.Windows.Visibility Pwd
            {
                get
                {
                    return pwd;
                }
                set
                {
                    pwd = value;
                    OnPropertyChanged("Pwd");
                }
            }
            private System.Windows.Visibility txtbox;
            public System.Windows.Visibility Txtbox
            {
                get
                {
                    return txtbox;
                }
                set
                {
                    txtbox = value;
                    OnPropertyChanged("Txtbox");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;





        public void Canexecute(object param)
        {


            if (param.ToString() == "ShowPassword")
            {
                Showvisibility = Visibility.Collapsed;
                Hidevisibility = Visibility.Visible;
                Pwd = Visibility.Collapsed;
                Txtbox = Visibility.Visible;


            }

            else if (param.ToString() == "HidePassword")
            {
                Hidevisibility = Visibility.Collapsed;
                Showvisibility = Visibility.Visible;
                Txtbox = Visibility.Collapsed;
                Pwd = Visibility.Visible;

            }

            else
            {
               if(param.ToString()==null || Name == null)
                {
            
                    MessageBox.Show("Password/ username Cannot be empty");
                }
               else if (Name == "grace" && param.ToString() == "1234")
                {
                  
                    MessageBox.Show("Login Successful");
                }
                else
                   
                MessageBox.Show("Invalid Credentials");

            }


        }

            public bool CanUse(object message)
            {
                return true;
            }

            public void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
            {
                if (!Equals(field, newValue))
                {
                    field = newValue;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }

                return false;
            }


        }
    }

