using FitnesClub.Model;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnesClub.ViewModel.AdministratorViewModel.ClientsViewModel
{
    class ListClientsPageViewModel : Helper.Helper
    {

        public ObservableCollection<clients> ListClients { get; set; }

        private clients selectedClient;
        public clients SelectedClient
        {
            get => this.selectedClient;
            set
            {
                this.selectedClient = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddClientCommand { get; set; }

        public ICommand RemoveClientCommand { get; set; }

        public ICommand ModifyClientCommand { get; set; }
        public ListClientsPageViewModel()
        {
            try
            {
                this.UpLoadData();
                AddClientCommand = new Command(AddClientCommandClick);
                RemoveClientCommand = new Command(RemoveClientCommandClick , CanRemoveCommand);
                ModifyClientCommand = new Command(ModifyClientCommandClick , CanModifyCommand);
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void UpLoadData()
        {
            context.clients.Load();
            this.ListClients = context.clients.Local;
        }
        private bool CanModifyCommand(object arg)
        {
            if (this.selectedClient == null) return false;
            return true; 
        }

        private void ModifyClientCommandClick(object obj)
        {
            try
            {
                this.context.SaveChanges();
                this.MessageBoxInformation("Данные о клиенте изменены");

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void RemoveClientCommandClick(object obj)
        {
            try
            {
                MessageBoxResult answer = this.MessageBoxQuestion("Удалить клиента", "удаление");
                if (answer == MessageBoxResult.Yes)
                {
                    this.context.clients.Remove(SelectedClient);
                    this.context.SaveChanges();
                    this.MessageBoxInformation("Клиент удален из таблицы");
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
            
        }

        private bool CanRemoveCommand(object arg)
        {
            if (this.selectedClient == null) return false;
            return true;
        }

        private void AddClientCommandClick(object obj)
        {
            try
            {
                View.Administrator.DialogWindows.DialogWindowSelectNewClient dialog = new View.Administrator.DialogWindows.DialogWindowSelectNewClient();
                if (dialog.ShowDialog() == true)
                {
                    if(Helper.HelperDialogWindows.NewClient is clients)
                    {
                        this.context.clients.Add(HelperDialogWindows.NewClient);
                        this.context.SaveChanges();
                        this.MessageBoxInformation("Клиент успешно добавлен в таблицу");
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная ошибка!Попробуйте снова", "ошибка", MessageBoxButton.OK , MessageBoxImage.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }
    }
}
