using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.DialogWindowsViewModel
{
    class DialogWindowSelectOldClientViewModel : Helper.HelperDialogWindows
    {
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

        public static Action CloseWindow { get; set; }

        public ICommand SelectClientCommand { get; set; }

        public DialogWindowSelectOldClientViewModel()
        {
            try
            {
                this.ListClients = this.context.clients.ToList();
                this.SelectClientCommand = new Command(SelectClientCommandClick, CanSelectClientCommand);
            }
            catch (Exception ex)
            {

                this.MessageBoxError(ex);
            }


        }

        private bool CanSelectClientCommand(object arg)
        {
            if (this.selectedClient == null) return false;
            return true;
        }

        private void SelectClientCommandClick(object obj)
        {
            FitnesClub.ViewModel.AdministratorViewModel.SubscriptionsViewModel.SubsctiprionsPageViewModel.OldClient = this.selectedClient;   
            CloseWindow();
        }
    }
}
