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
    class ListEventsPageIronViewModel : EventsHepler
    {
        public List<Model.amenities> ListEventsIron { get; set; }

        private Model.amenities selectedEventIron;
        public Model.amenities SelectedEventIron
        {
            get
            {

                return this.selectedEventIron;
            }
            set
            {
                this.selectedEventIron = value;
                OnPropertyChanged();
            }
        }


        public ICommand RecordingCommand { get; set; }

        public ICommand TogetherChangeCommand { get; set; }

        public ListEventsPageIronViewModel()
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.ListEventsIron = this.UpLoadData(3);

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
            return this.CanExecuteSelectedEvent(this.selectedEventIron);
        }

        private bool CanRecordingCommand(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventIron);
        }
    }
}
