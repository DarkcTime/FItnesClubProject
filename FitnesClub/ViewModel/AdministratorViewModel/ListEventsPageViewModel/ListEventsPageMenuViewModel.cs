using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ListEventsPageViewModel
{

    class ListEventsPageMenuViewModel : ViewModelProp
    {
        public Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand FitnesCommand { get; set; }
        public ICommand DanceCommand { get; set; }
        public ICommand IronCommand { get; set; }
        public ICommand YogaCommand { get; set; }

        public ListEventsPageMenuViewModel()
        {
            FitnesCommand = new Command(FitnesCommandClick);

            DanceCommand = new Command(DanceCommandClick);

            IronCommand = new Command(IronCommandClick);

            YogaCommand = new Command(YogaCommandClick);
        }

        private void YogaCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.ListEventsPage.ListEventsPageYoga();
        }

        private void IronCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.ListEventsPage.ListEventPageIron();
        }

        private void DanceCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.ListEventsPage.ListEventsPageDance();
        }

        private void FitnesCommandClick(object obj)
        {
            CurrentPage = new View.Administrator.ListEventsPage.ListEventsPageFitnes();
        }
    }
}
