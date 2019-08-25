
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FitnesClub.ViewModel.Helper
{
    class EventsHepler : ViewModelProp
    {
        //создание объекта модели
        protected Model.FitnesClubEntities context = new Model.FitnesClubEntities();

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
