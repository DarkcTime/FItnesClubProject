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

        public List<Model.discont> ListDisconts { get; set; }

        public int IndexDiscont { get; set; }

        private Model.subscribe selectedSubscribe;
        public Model.subscribe SelectedSubscribe
        {
            get => this.selectedSubscribe;
            set
            {
                this.selectedSubscribe = value;
                OnPropertyChanged();
            }
        }

        private string firstName,middleName;
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

        private Model.discont selectedDiscont;
        public Model.discont SelectedDiscont
        {
            get => this.selectedDiscont;
            set
            {
                this.selectedDiscont = value;
                OnPropertyChanged();
            }
        }

        private string numberDiscont;
        public string NumberDiscont
        {
            get => this.numberDiscont;
            set
            {
                this.numberDiscont = $"{this.selectedDiscont.number}%";
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
                this.UpLoadData();
                this.NewClientCommand = new Command(NewClientCommandClick);
                this.OldClientCommand = new Command(OldClientCommandClick);
                this.PayCommand = new Command(PayCommandClick, CanPayCommand);
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
 
        }
        private void UpLoadData()
        {
            this.ListSubscriptions = this.context.subscribe.ToList();
            this.ListDisconts = this.context.discont.ToList();
            this.IndexDiscont = 0;            
        }

        private bool CanPayCommand(object arg)
        {
            if (this.selectedSubscribe == null || string.IsNullOrWhiteSpace(this.firstName)) return false;
            return true;
        }

        private void PayCommandClick(object obj)
        {
            Model.buy buy;
            if (HelperDialogWindows.SelectedClientOld != null && this.FirstName == HelperDialogWindows.SelectedClientOld.FirstName)
            {
                buy = new Model.buy()
                {
                    client_id = HelperDialogWindows.SelectedClientOld.id_client,
                    subsribe_id = this.selectedSubscribe.id_subscribe,
                    discont_id = this.selectedDiscont.id_discont,
                    date_buy = DateTime.Now
                };             
            }
            else
            {
                this.context.clients.Add(Helper.HelperDialogWindows.NewClient);
                buy = new Model.buy()
                {
                    client_id = HelperDialogWindows.NewClient.id_client,
                    subsribe_id = this.selectedSubscribe.id_subscribe,
                    discont_id = this.selectedDiscont.id_discont,
                    date_buy = DateTime.Now
                };
            }
            this.context.buy.Add(buy);
            this.context.SaveChanges();
            MessageBoxInformation("Данные добавлены в лист покупок");
            this.FirstName = "";
            this.MiddleName = "";
        }

        private void OldClientCommandClick(object obj)
        {
            View.Administrator.DialogWindows.DialogWindowSelectOldClient dialogWindowSelectOldClient = new View.Administrator.DialogWindows.DialogWindowSelectOldClient();
            if(dialogWindowSelectOldClient.ShowDialog() == true)
            {
                this.FirstName = HelperDialogWindows.SelectedClientOld.FirstName;
                this.MiddleName = HelperDialogWindows.SelectedClientOld.MiddleName;
            }
        }

        private void NewClientCommandClick(object obj)
        {
            View.Administrator.DialogWindows.DialogWindowSelectNewClient dialogWindowSelectNewClient = new View.Administrator.DialogWindows.DialogWindowSelectNewClient();
            if (dialogWindowSelectNewClient.ShowDialog() == true)
            {
                this.FirstName = Helper.HelperDialogWindows.NewClient.FirstName;
                this.MiddleName = Helper.HelperDialogWindows.NewClient.MiddleName;
            }
        }


    }
}
