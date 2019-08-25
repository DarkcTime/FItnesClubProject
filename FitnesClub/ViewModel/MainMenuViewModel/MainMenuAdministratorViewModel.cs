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
    class MainMenuAdministratorViewModel : ViewModelProp
    { 

        public static Action CloseThisWindow { get;set; }

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
        public ICommand BeatyServicesCommand { get; set; }
        public ICommand ClientCommand { get; set; }
        public ICommand ListRecordsCommand { get; set; }

        public ICommand ChangeUserCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public MainMenuAdministratorViewModel()
        {

            SubscribesCommand = new Command(SubscribesCommandClick);
            ListEventsCommand = new Command(ListEventsCommandClick);
            ListRecordsCommand = new Command(ListRecordsCommandClick);
            ClientCommand = new Command(ClientCommandClick);
        }

        private void SubscribesCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.Subscriptions.SubscriprionsPage();
        }

        private void ListRecordsCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.ListRecords.ListRecordsPage();
        }

        private void ClientCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.Clients.ListClientsPage();
        }

        private void ListEventsCommandClick(object obj)
        {

            CurrentPage = new View.Administrator.ListEventsPage.ListEventsPageMenu();
            
        }
    }
}
