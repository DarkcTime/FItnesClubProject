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

namespace FitnesClub.View.Administrator.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для DialogWindowSelectNewClient.xaml
    /// </summary>
    public partial class DialogWindowSelectNewClient : Window
    {
        public DialogWindowSelectNewClient()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdministratorViewModel.DialogWindowsViewModel.DialogWindowSelectNewClientViewModel();
            ViewModel.Helper.HelperDialogWindows.DialogResult = new Action(() => this.DialogResult = true);
        }

        private void TextBox_PreviewTextInputFirstName(object sender, TextCompositionEventArgs e)
        {
            ViewModel.Helper.Helper.OnlyLetter(e , "");
        }
        private void TextBox_PreviewTextInputMiddleName(object sender, TextCompositionEventArgs e)
        {
            ViewModel.Helper.Helper.OnlyLetter(e, "");
        }
        private void TextBox_PreviewTextInputLastName(object sender, TextCompositionEventArgs e)
        {
            ViewModel.Helper.Helper.OnlyLetter(e, "");
        }
    }
    
}
