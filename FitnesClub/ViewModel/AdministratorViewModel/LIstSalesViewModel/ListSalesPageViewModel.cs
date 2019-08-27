using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesClub.ViewModel.AdministratorViewModel.LIstSalesViewModel
{
    class ListSalesPageViewModel : Helper.Helper
    {
        private List<NewSales> listSales;
        public List<NewSales> ListSales
        {
            get => this.listSales;
            set
            {
                this.listSales = value;
                OnPropertyChanged();
            }
        }
         
        public ListSalesPageViewModel()
        {
            this.ListSales = this.context.buy.Select(i => new NewSales { сумма = i.subscribe.price - i.subscribe.price * i.discont.number / 100, name = i.subscribe.name,
            discont = i.discont.number , type = i.subscribe.type_subscribe.name , price = i.subscribe.price , clientFirstName = i.clients.FirstName}).ToList(); 
            //ListSales.FirstOrDefault().
        }
    }
}
