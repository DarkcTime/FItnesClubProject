using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnesClub.ViewModel.Helper
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        readonly Action<object> execute;
        readonly Func<object, bool> canExecute;
        private ICommand registrationCommand;

        public Command(Action<object> action , Func<object, bool> func = null)
        {
            execute = action;
            canExecute = func;
        }

       

        public bool CanExecute(object parameter)
        {
            if (canExecute != null) return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
