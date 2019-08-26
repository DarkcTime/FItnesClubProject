using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ListEventsPageViewModel
{
    class ListEventsPageFitnesViewModel : EventsHepler
    {
      
       
        public List<Model.amenities> ListEventsFitnes { get; set; }

        private Model.amenities selectedEventFitnes;


        public Model.amenities SelectedEventFitnes
        {
            get
            {
                               
                return this.selectedEventFitnes;
            }
            set
            {
                this.selectedEventFitnes = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand RecordingCommand { get; set; }

        public ICommand TogetherChangeCommand { get; set; }
        //TODO изменять ComboBox при выборе 
        public ListEventsPageFitnesViewModel()
        {
            try
            {
                this.ListEventsFitnes = this.UpLoadData(1);

                this.RecordingCommand = new Command(RecordingCommandClick, CanRecordingCommand);
                this.TogetherChangeCommand = new Command(TogetherChangeCommandClick, CanTogetherChange);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.HelpLink , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            
        }

        private void RecordingCommandClick(object obj)
        {
            try
            {
                this.RecordClientOnTraining(this.selectedEventFitnes);
                
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);        
            }
            
        }
        private void TogetherChangeCommandClick(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanTogetherChange(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventFitnes);
        }

        private bool CanRecordingCommand(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventFitnes);
        }

        


       
    }

 
}
