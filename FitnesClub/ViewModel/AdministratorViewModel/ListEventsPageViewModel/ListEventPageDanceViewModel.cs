using FitnesClub.Model;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ListEventsPageViewModel
{
    class ListEventPageDanceViewModel : EventsHepler
    {
        
        public List<Model.amenities> ListEventsDance { get; set; }

        private Model.amenities selectedEventDance;
        public Model.amenities SelectedEventDance
        {
            get
            {

                return this.selectedEventDance;
            }
            set
            {
                this.selectedEventDance = value;
                OnPropertyChanged();
            }
        }


        public ICommand RecordingCommand { get; set; }

        public ICommand TogetherChangeCommand { get; set; }
      
        public ListEventPageDanceViewModel()
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.ListEventsDance = this.UpLoadData(2);

            this.RecordingCommand = new Command(RecordingCommandClick, CanRecordingCommand);
            this.TogetherChangeCommand = new Command(TogetherChangeCommandClick, CanTogetherChange);
        }


       
        private void RecordingCommandClick(object obj)
        {
            throw new NotImplementedException();
        }
        private void TogetherChangeCommandClick(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanTogetherChange(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventDance);
        }

        private bool CanRecordingCommand(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventDance);
        }
       
    }
}

