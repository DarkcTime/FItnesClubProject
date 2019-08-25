using FitnesClub.ViewModel.AdministratorViewModel.ListEventsPageViewModel.DialogWindowListEventsViewModel;
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

namespace FitnesClub.View.Administrator.ListEventsPage.DialogWindowListEvents
{
    /// <summary>
    /// Логика взаимодействия для DialogWindowRecordClient.xaml
    /// </summary>
    public partial class DialogWindowRecordClient : Window
    {
        public DialogWindowRecordClient()
        {
            InitializeComponent();
            DialogWindowRecordClientViewModel.CloseWindow = new Action(() => this.DialogResult = true);
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PopupListClient.IsOpen = true;
        }
    }
}
