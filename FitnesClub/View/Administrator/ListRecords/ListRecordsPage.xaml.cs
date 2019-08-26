using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnesClub.View.Administrator.ListRecords
{
    /// <summary>
    /// Логика взаимодействия для ListRecordsPage.xaml
    /// </summary>
    public partial class ListRecordsPage : Page
    {
        public ListRecordsPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdministratorViewModel.LIstRecordsViewModel.ListRecordsPageViewModel();
        }
    }
}
