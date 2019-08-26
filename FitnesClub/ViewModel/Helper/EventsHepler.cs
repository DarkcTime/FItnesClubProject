
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FitnesClub.ViewModel.Helper
{
    class EventsHepler : Helper
    {
        //создание объекта модели
        protected Model.FitnesClubEntities context = new Model.FitnesClubEntities();

        protected void RecordClientOnTraining(Model.amenities selectedEvent)
        {
            View.Administrator.DialogWindows.DialogWindowSelectOldClient dialogWindowSelectOld = new View.Administrator.DialogWindows.DialogWindowSelectOldClient();
            
            if (dialogWindowSelectOld.ShowDialog() == true)
            {
                Model.exercise exercise = new Model.exercise()
                {
                    service_id = selectedEvent.id_servise,
                    client_id = HelperDialogWindows.SelectedClientOld.id_client,
                    date_write = DateTime.Now
                };
                this.context.exercise.Add(exercise);
                this.context.SaveChanges();
                MessageBox.Show("Клиент записан на тренировку", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Метод определяющий доступна ли кнопка 
        /// </summary>
        /// <param name="selectedEvent">свойство привязанное к SelectedItem DataGrid</param>
        /// <returns>Значение доступа</returns>
        protected bool CanExecuteSelectedEvent(Model.amenities selectedEvent)
        {
            if (selectedEvent == null)
            {
                return false;
            }
            return true;
            
        }
      /// <summary>
      /// Метод загружающий данные в коллекцию связанную с DataGrid
      /// </summary>
      /// <param name="gym_id">Номер зала</param>
      /// <returns>коллецию отфильтрованных данных</returns>
        protected List<Model.amenities> UpLoadData(int gym_id)
        {
            List<Model.amenities> listEvents = context.amenities.Where(i => i.gym_id == gym_id).OrderBy(c => c.day_id).ToList();
            return listEvents;
        }
    }
}
