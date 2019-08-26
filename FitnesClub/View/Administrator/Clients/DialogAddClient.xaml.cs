using FitnesClub.ViewModel.AdministratorViewModel.ClientsViewModel;
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
using System.Windows.Shapes;

namespace FitnesClub.View.Administrator.Clients
{
    /// <summary>
    /// Логика взаимодействия для DialogAddClient.xaml
    /// </summary>
    public partial class DialogAddClient : Window
    {
        public DialogAddClient()
        {
            InitializeComponent();
            DialogAddClientViewModel.ClosedWindow = new Action(() => this.DialogResult = true); ;
        }
    }
}
