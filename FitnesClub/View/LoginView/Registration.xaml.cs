using FitnesClub.ViewModel.Helper;
using FitnesClub.ViewModel.LoginViewModel;
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

namespace FitnesClub.View.Login
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            RegistrationViewModel vm = new RegistrationViewModel();
            DataContext = vm;
            vm.CloseWindow = new Action(() => this.Close());
        }

        private void TextBox_PreviewTextInputFirstName(object sender, TextCompositionEventArgs e)
        {
            if (Int32.TryParse(e.Text, out int res))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInputMiddleName(object sender, TextCompositionEventArgs e)
        {
            if (Int32.TryParse(e.Text, out int res))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInputLastName(object sender, TextCompositionEventArgs e)
        {
            if (Int32.TryParse(e.Text, out int res))
            {
                e.Handled = true;
            }
        }
    }
}
