using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.SubscriptionsViewModel
{
    class SubsctiprionsPageViewModel : Helper.Helper
    {
        private List<Model.subscribe> listSubscriptions;
        public List<Model.subscribe> ListSubscriptions
        {
            get => this.listSubscriptions;
            set
            {
                this.listSubscriptions = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewClientCommand { get; set; }
        public ICommand OldClientCommand { get; set; }
        public ICommand PayCommand { get; set; }
        public SubsctiprionsPageViewModel()
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
          
            ListSubscriptions = this.context.subscribe.ToList();
            NewClientCommand = new Command(NewClientCommandClick, CanNewClientCommand);
            OldClientCommand = new Command(OldClientCommandClick, CanOldClientCommand);
            this.PayCommand = new Command(PayCommandClick, CanPayCommand);
        }

        private bool CanPayCommand(object arg)
        {
            throw new NotImplementedException();
        }

        private void PayCommandClick(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanOldClientCommand(object arg)
        {
            throw new NotImplementedException();
        }

        private void OldClientCommandClick(object obj)
        {
            throw new NotImplementedException();
        }

        private void NewClientCommandClick(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanNewClientCommand(object arg)
        {
            throw new NotImplementedException();
        }
    }
}
