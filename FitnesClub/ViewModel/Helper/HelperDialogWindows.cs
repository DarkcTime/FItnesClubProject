using FitnesClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesClub.ViewModel.Helper
{
    class HelperDialogWindows : Helper
    {
        protected FitnesClubEntities context = new FitnesClubEntities();
       

        public static Model.clients SelectedClientOld { get; set; }
        public static Model.clients NewClient { get; set; }
        public static Action DialogResult { get; set; }
    }
}
