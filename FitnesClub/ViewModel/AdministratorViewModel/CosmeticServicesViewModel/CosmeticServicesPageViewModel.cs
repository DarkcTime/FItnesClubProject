using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.CosmeticServicesViewModel
{
    class CosmeticServicesPageViewModel : Helper.HelperDialogWindows
    {
        public List<Model.beauty_services> ListCosmeticServices { get; set; }

        private Model.beauty_services selectedService;
        public Model.beauty_services SelectedService
        {
            get => this.selectedService;
            set
            {
                this.selectedService = value;
                OnPropertyChanged();
            }
        }

        private string firstName, middleName;
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

        public static Model.clients NewClient { get; set; }
        public static Model.clients OldClient { get; set; }
        public ICommand NewClientCommand { get; set; }
        public ICommand OldClientCommand { get; set; }
        public ICommand RecordCommand { get; set; }

        public CosmeticServicesPageViewModel()
        {
            try
            {
                this.UpLoadData();
                ViewModel.Helper.HelperDialogWindows.CurrentPage = "CosmeticService";
                this.NewClientCommand = new Command(NewClientCommandClick);
                this.OldClientCommand = new Command(OldClientCommandClick);
                this.RecordCommand = new Command(RecordCommandClick, CanRecordCommand);
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
          
        }
        private void UpLoadData()
        {
            this.ListCosmeticServices = context.beauty_services.ToList();

        }

        private void RecordCommandClick(object obj)
        {
            Model.beauty_servise_list beauty_Servise_List;
            if (OldClient != null && this.FirstName == OldClient.FirstName)
            {
                 beauty_Servise_List = new Model.beauty_servise_list()
                {
                    client_id = OldClient.id_client,
                    service_beaty_id = this.selectedService.id_service,
                    date_buy = DateTime.Now
                };
                this.context.beauty_servise_list.Add(beauty_Servise_List);
                        }
            else
            {
                this.context.clients.Add(NewClient);
                beauty_Servise_List = new Model.beauty_servise_list()
                {
                    client_id = NewClient.id_client,
                    service_beaty_id = this.selectedService.id_service,
                    date_buy = DateTime.Now
                };
               
            }

            this.context.beauty_servise_list.Add(beauty_Servise_List);
            this.context.SaveChanges();
            this.MessageBoxInformation("Клиент записан на косметическую процедуру(Список записи на процедуры может посмотреть косметолог)");

        }

        private bool CanRecordCommand(object arg)
        {
            if (string.IsNullOrWhiteSpace(this.FirstName) || this.selectedService == null) return false;
            return true;
        }

        private void OldClientCommandClick(object obj)
        {
            View.Administrator.DialogWindows.DialogWindowSelectOldClient dialogOldClient = new View.Administrator.DialogWindows.DialogWindowSelectOldClient();           
            if (dialogOldClient.ShowDialog() == true)
            {
                this.FirstName = OldClient.FirstName;
                this.MiddleName = OldClient.MiddleName;
            }
        }

        private void NewClientCommandClick(object obj)
        {
            View.Administrator.DialogWindows.DialogWindowSelectNewClient dialogNewClient = new View.Administrator.DialogWindows.DialogWindowSelectNewClient();
            if (dialogNewClient.ShowDialog() == true)
            {
                this.FirstName = NewClient.FirstName;
                this.MiddleName = NewClient.MiddleName;
            }
        }
    }
}
