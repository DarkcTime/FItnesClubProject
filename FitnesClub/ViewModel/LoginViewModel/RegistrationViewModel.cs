using FitnesClub.Model;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.LoginViewModel
{
    class RegistrationViewModel : HelperDialogWindows
    {

        private string firtsNameClient, middleNameClient, lastNameClient, emailClient, loginClient, passwordClient;

        public string FirtsNameClient
        {
            get => firtsNameClient;
            set
            {
                firtsNameClient = value;
                OnPropertyChanged();
            }
        }

        public string MiddleNameClient
        {
            get => middleNameClient;
            set
            {
                middleNameClient = value;
                OnPropertyChanged();
            }
        }

        public string LastNameClient
        {
            get => lastNameClient;
            set
            {
                lastNameClient = value;
                OnPropertyChanged();
            }
        }

        public string EmailClient
        {
            get => emailClient;
            set
            {
                emailClient = value;
                OnPropertyChanged();
            }
        }

        public string LoginClient
        {
            get => loginClient;
            set
            {
                loginClient = value;
                OnPropertyChanged();
            }
        }

        public string PasswordClient
        {
            get => passwordClient;
            set
            {
                passwordClient = value;
                OnPropertyChanged();
            }
        }

        private int ageClient;

        public int AgeClient
        {
            get => ageClient;
            set
            {
                ageClient = value;
                OnPropertyChanged();
            }
        }
        public ICommand RegistrationCommand { get; set; }
       
        public RegistrationViewModel()
        {
            AgeClient = 10;
            RegistrationCommand = new Command(RegistrationCommandClick, CanRegistrationCommand);
        }

        private bool CanRegistrationCommand(object arg)
        {
            if (string.IsNullOrWhiteSpace(this.FirtsNameClient) || string.IsNullOrWhiteSpace(this.MiddleNameClient) 
                || string.IsNullOrWhiteSpace(this.LoginClient) || string.IsNullOrWhiteSpace(this.PasswordClient)) return false;
            return true;
        }

        private void RegistrationCommandClick(object obj)
        {
            //TODO переделать метод регистрации )) 
            try
            {
                users User = new users()
                {
                    login = LoginClient,
                    password = PasswordClient,
                    type_user_id = 4
                };
                context.users.Add(User);


                clients Client = new clients()
                {
                    FirstName = FirtsNameClient,
                    MiddleName = MiddleNameClient,
                    LastName = LastNameClient,
                    age = AgeClient,
                    Email = emailClient,
                    account_id = User.id_user
                };
                context.clients.Add(Client);
                context.SaveChanges();               
                Helper.HelperDialogWindows.DialogResult();
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
          
            
            
        }
    }
}
