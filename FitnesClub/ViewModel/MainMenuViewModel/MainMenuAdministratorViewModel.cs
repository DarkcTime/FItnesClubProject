using FitnesClub.View.Administrator;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnesClub.ViewModel.MainMenuViewModel
{
    class MainMenuAdministratorViewModel : MenuHelper
    {       

        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        public ICommand ListEventsCommand { get; set; }
        public ICommand SubscribesCommand { get; set; }
        public ICommand CosmeticServicesCommand { get; set; }
        public ICommand ClientCommand { get; set; }
        public ICommand ListRecordsCommand { get; set; }

        public ICommand ChangeUserCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public MainMenuAdministratorViewModel()
        {
            try
            {
                CosmeticServicesCommand = new Command(CosmeticServicesCommandClick);
                SubscribesCommand = new Command(SubscribesCommandClick);
                ListEventsCommand = new Command(ListEventsCommandClick);
                ListRecordsCommand = new Command(ListRecordsCommandClick);
                ClientCommand = new Command(ClientCommandClick);

                ChangeUserCommand = new Command(ChangeUserCommandClick);
                ExitCommand = new Command(ExitCommandClick);
    }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
            
        }

        private void ExitCommandClick(object obj)
        {
            this.ApplicationShutDown();
        }

        private void ChangeUserCommandClick(object obj)
        {
            this.GoToTheLoginWindow();
        }

        private void CosmeticServicesCommandClick(object obj)
        {
            this.CurrentPage = new View.Administrator.CosmeticServices.CosmeticServicesPage();
        }

        private void SubscribesCommandClick(object obj)
        {
            this.CurrentPage = new View.Administrator.Subscriptions.SubscriprionsPage();
        }

        private void ListRecordsCommandClick(object obj)
        {
            this.CurrentPage = new View.Administrator.ListRecords.ListRecordsPage();
        }

        private void ClientCommandClick(object obj)
        {
            this.CurrentPage = new View.Administrator.Clients.ListClientsPage();
        }

        private void ListEventsCommandClick(object obj)
        {

            this.CurrentPage = new View.Administrator.ListEventsPage.ListEventsPageMenu();
            
        }
    }
}
