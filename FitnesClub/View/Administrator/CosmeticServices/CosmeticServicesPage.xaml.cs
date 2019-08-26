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

namespace FitnesClub.View.Administrator.CosmeticServices
{
    /// <summary>
    /// Логика взаимодействия для CosmeticServicesPage.xaml
    /// </summary>
    public partial class CosmeticServicesPage : Page
    {
        public CosmeticServicesPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdministratorViewModel.CosmeticServicesViewModel.CosmeticServicesPageViewModel();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PopupService.IsOpen = true;
        }
    }
}
