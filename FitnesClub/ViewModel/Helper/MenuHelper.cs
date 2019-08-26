using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnesClub.ViewModel.Helper
{
    class MenuHelper : Helper 
    {
        public static Action CloseWindow;
        /// <summary>
        /// Закрывает приложение после потверждения
        /// </summary>
        protected void ApplicationShutDown()
        {
            var answer = this.MessageBoxQuestion("Закрывать приложение", "Выход");
            if(answer == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }

        }
        /// <summary>
        /// Закрывает окно меню и переходит в окно авторизации
        /// </summary>
        protected void GoToTheLoginWindow()
        {
            var answer = MessageBox.Show("Перейти в окно авторизации", "Сменить пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                this.ShowLoginWindow();
                CloseWindow();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Открывает окно авторизации
        /// </summary>
        private void ShowLoginWindow()
        {
            View.LoginView.Authorization authorization = new View.LoginView.Authorization();
            authorization.Show();
            return;
        }

    }
}
