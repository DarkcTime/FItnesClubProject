using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnesClub.ViewModel.Helper
{
    class MenuHeplper 
    {

        public static void ApplicationShutDown()
        {
            var answer = MessageBox.Show("Закрыть приложение", "Выход",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(answer == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }

        }

        public static bool GoToTheLoginWindow()
        {
            var answer = MessageBox.Show("Перейти в окно авторизации", "Сменить пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowLoginWindow()
        {
            View.LoginView.Authorization authorization = new View.LoginView.Authorization();
            authorization.Show();
            return;
        }

    }
}
