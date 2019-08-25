using FitnesClub.Model;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ListEventsPageViewModel.DialogWindowListEventsViewModel
{
    class DialogWindowRecordClientViewModel : ViewModelProp
    {

        FitnesClubEntities context = new FitnesClubEntities();

        public List<Model.clients> ListClients { get; set; }

        private Model.clients selectedClient;
        public Model.clients SelectedClient
        {
            get => this.selectedClient;
            set
            {
                this.selectedClient = value;
                OnPropertyChanged();
            }
        }

        public static Model.amenities CurrentEvent { get; set; }
        public static Action CloseWindow { get; set; }

        public ICommand RecordCommand { get; set; }

        public DialogWindowRecordClientViewModel()
        {
            try
            {
                this.ListClients = this.context.clients.ToList();
                this.RecordCommand = new Command(RecordCommandClick, CanExecuteRecordCommand);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private bool CanExecuteRecordCommand(object arg)
        {
            if (this.selectedClient == null) return false;
            return true;
        }

        private void RecordCommandClick(object obj)
        {
            Model.exercise exercise = new exercise()
            {
                service_id = CurrentEvent.id_servise,
                client_id = this.selectedClient.id_client,
                date_write = DateTime.Now
            };
            this.context.exercise.Add(exercise);
            this.context.SaveChanges();
            CloseWindow(); 
        }
    }
}
