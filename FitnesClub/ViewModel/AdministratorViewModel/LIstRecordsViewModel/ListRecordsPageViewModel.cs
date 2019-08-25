using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.LIstRecordsViewModel
{
    class ListRecordsPageViewModel : Helper.Helper
    {
        private List<Model.exercise> listRecords;
        public List<Model.exercise> ListRecords
        {
            get
            {              
                return this.listRecords;
            }               
            set
            {
                this.listRecords = value;
                OnPropertyChanged();
            }
        }

        public List<Model.gym> ListGymsComboBox { get; set; }

        private Model.gym selectedGym;
        public Model.gym SelectedGym
        {
            get => this.selectedGym;
            set
            {
                this.selectedGym = value;
                OnPropertyChanged();
            }
        }

        public List<Model.employees> ListTrenersComboBox { get; set; }

        private Model.employees selectedTrener;
        public Model.employees SelectedTrener
        {
            get => this.selectedTrener;
            set
            {
                this.selectedTrener = value;
                OnPropertyChanged();
            }
        }
        public List<Model.amenities> ListTrainingsComboBox { get; set; }

        private Model.amenities selectedTraining;
        public Model.amenities SelectedTraining
        {
            get => this.selectedTraining;
            set
            {
                this.selectedTraining = value;
                OnPropertyChanged();
            }
        }
        public List<Model.clients> ListClientsComboBox { get; set; }
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
        public ICommand UpdateRecordsCommand { get; set; }

        public ListRecordsPageViewModel()
        {
            try
            {
                this.UpLoadData();
                this.UpdateRecordsCommand = new Command(UpdateRecordsCommandClick, CanUpdateRecordsCommand);
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }

        }

        private bool CanUpdateRecordsCommand(object arg)
        {
            if (this.selectedClient == null && this.selectedGym == null && this.selectedTrener == null && this.selectedTraining == null) return false;
            return true;
        }

        private void UpdateRecordsCommandClick(object obj)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }

            this.UpdateData();
        }

        private void UpLoadData()
        {
            this.ListRecords = this.context.exercise.ToList();
            this.ListClientsComboBox = this.context.clients.ToList();
            this.ListGymsComboBox = this.context.gym.ToList();
            this.ListTrainingsComboBox = this.context.amenities.ToList();
            this.ListTrenersComboBox = this.context.employees.ToList();
        }

        private void UpdateData()
        {
            List<Model.exercise> listRecordsFilter;
            listRecordsFilter = this.context.exercise.ToList();
            if (this.selectedGym != null)
            {
                listRecordsFilter = listRecordsFilter.Where(i => i.amenities.gym_id == this.selectedGym.id_gym).ToList();
            }
            if(this.selectedClient != null)
            {
                listRecordsFilter = listRecordsFilter.Where(i => i.client_id == this.selectedClient.id_client).ToList();
            }
            if(this.selectedTrener != null)
            {
                listRecordsFilter = listRecordsFilter.Where(i => i.amenities.employees_id == this.selectedTrener.id_employees).ToList();
            }
            if(this.selectedTraining != null)
            {
                listRecordsFilter = listRecordsFilter.Where(i => i.amenities.name_id == this.selectedTraining.id_servise).ToList();
            }
            this.ListRecords = listRecordsFilter;             
        }
    }
}
