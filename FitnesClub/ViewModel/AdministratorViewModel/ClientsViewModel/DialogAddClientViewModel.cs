using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ClientsViewModel
{
    class DialogAddClientViewModel : Helper.Helper
    {
        public static Action ClosedWindow { get; set; }

        private string firstName, middleName, lastName, email; 

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => this.middleName;
            set
            {
                this.middleName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
                OnPropertyChanged();
            }
        }

        private int age;

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public DialogAddClientViewModel()
        {
            try
            {
                Age = 10;
                AddCommand = new Command(AddCommandClick , CanAddCommand);
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void AddCommandClick(object obj)
        {
            try
            {
                Model.clients client = new Model.clients()
                {
                    FirstName = this.firstName,
                    MiddleName = this.middleName,
                    LastName = this.lastName,
                    age = this.age,
                    Email = this.email
                };
                ListClientsPageViewModel.NewClient = client;
                ClosedWindow();
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private bool CanAddCommand(object arg)
        {
            if (string.IsNullOrWhiteSpace(this.FirstName) || string.IsNullOrWhiteSpace(this.MiddleName)) return false;
            return true;
        }
    }
}
