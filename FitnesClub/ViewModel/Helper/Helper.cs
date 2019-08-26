using FitnesClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.Helper
{
    class Helper : ViewModelProp
    {
        protected FitnesClubEntities context = new FitnesClubEntities();
        
        public static void OnlyNumber(TextCompositionEventArgs e)
        {
            if (!Int32.TryParse(e.Text, out int res))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Позволяет вводить в текстовое поле только буквы 
        /// </summary>
        /// <param name="e"></param>
        public static void OnlyLetter(TextCompositionEventArgs e)
        {
            if (Int32.TryParse(e.Text, out int res))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Выводит диалоговое окно с информацией
        /// </summary>
        /// <param name="message"></param>
        protected void MessageBoxInformation(string message)
        {
            MessageBox.Show(message, "успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Выводит диалоговое окно с информацией
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        protected void MessageBoxInformation(string message , string title)
        {
            MessageBox.Show(message,title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Выводит диалоговое окно с ошибкой
        /// </summary>
        /// <param name="exception"></param>
        protected void MessageBoxError(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Выводит диалоговое окно с ошибкой
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns>ответ пользователя</returns>
        protected MessageBoxResult MessageBoxQuestion(string message, string title)
        {
            return MessageBox.Show(message, title , MessageBoxButton.YesNo , MessageBoxImage.Question);
        }


    }
}
