using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesClub.ViewModel.Helper
{
    class HelperLogin : Helper
    {
        protected Model.FitnesClubEntities context = new Model.FitnesClubEntities();

        public static Action CloseWindow;
    }
}
