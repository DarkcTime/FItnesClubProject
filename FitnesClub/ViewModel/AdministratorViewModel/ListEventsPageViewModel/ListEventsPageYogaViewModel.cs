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
    class ListEventsPageYogaViewModel : EventsHepler
    {
        public List<Model.amenities> ListEventsYoga { get; set; }

        private Model.amenities selectedEventYoga;
        public Model.amenities SelectedEventYoga
        {
            get
            {

                return this.selectedEventYoga;
            }
            set
            {
                this.selectedEventYoga = value;
                OnPropertyChanged();
            }
        }


        public ICommand RecordingCommand { get; set; }

        public ICommand TogetherChangeCommand { get; set; }

        public ListEventsPageYogaViewModel()
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.ListEventsYoga = this.UpLoadData(4);

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
            return this.CanExecuteSelectedEvent(this.selectedEventYoga);
        }

        private bool CanRecordingCommand(object arg)
        {
            return this.CanExecuteSelectedEvent(this.selectedEventYoga);
        }
    }
}
