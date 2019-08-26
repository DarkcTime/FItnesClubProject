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
        public static string CurrentPage { get; set; }

        public static Action DialogResult { get; set; }
    }
}
