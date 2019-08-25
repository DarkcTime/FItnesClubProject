using FitnesClub.Model;
using FitnesClub.View.Login;
using FitnesClub.View.MainMenu;
using FitnesClub.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace FitnesClub.ViewModel.LoginViewModel
{
    class AuthorizationViewModel : ViewModelProp
    {
        FitnesClubEntities context = new FitnesClubEntities();

        private string login, password; 

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public static users CurrentUser { get; set; }

        public ICommand RegistrationCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public bool IsCheckedMemberMe { get; set; }
        public Action CloseAction { get; set; }

        public AuthorizationViewModel()
        {
            try
            {
                this.IsCheckedMemberMe = true;
                this.ReadMemberMe();
                RegistrationCommand = new Command(RegistrationCommandClick);
                LoginCommand = new Command(LoginCommandClick, CanLoginCommandClick);
                ExitCommand = new Command(ExitCommandClick);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,ex.HelpLink,MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }

        private void RegistrationCommandClick(object obj)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.ShowDialog();            
        }

        private bool CanLoginCommandClick(object arg)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password)) return false;
            return true;
        }

        private void WriteMemberMeTrue()
        {
            using (StreamWriter sw = new StreamWriter("Member.txt",false, Encoding.UTF8))
            {
                sw.WriteLine(this.login);
                sw.WriteLine(this.password);
            }
        }

        private void WriteMemberMeFalse()
        {
            using (StreamWriter sw = new StreamWriter("Member.txt", false, Encoding.UTF8))
            {
            }
        }
        private void ReadMemberMe()
        {
            using (StreamReader sr = new StreamReader("Member.txt", Encoding.UTF8))
            {
                this.Login = sr.ReadLine();
                this.Password = sr.ReadLine();
            }
        }
        private void LoginCommandClick(object obj)
        {
            try
            {
                var currentUser = this.context.users.Where(i => i.login == Login && i.password == Password);
                if (currentUser.Count() > 0)
                {
                    if(this.IsCheckedMemberMe == true)
                    {
                        this.WriteMemberMeTrue();
                    }
                    else
                    {
                        this.WriteMemberMeFalse();
                    }
                    users currentUserFirstOrDefault = currentUser.FirstOrDefault();

                    AuthorizationViewModel.CurrentUser = currentUserFirstOrDefault;

                    if (currentUserFirstOrDefault.type_user_id == 1)
                    {
                        MessageBox.Show("Вы вошли как администратор", "авторизация прошла успешно" , MessageBoxButton.OK, MessageBoxImage.Information);
                        var mainAdministrator = new View.MainMenu.MainMenuAdministrator();
                        mainAdministrator.Show();
                    }
                    else if (currentUserFirstOrDefault.type_user_id == 2)
                    {
                        MessageBox.Show("Вы вошли как тренер", "авторизация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        var mainTrener = new MainMenuTrener();
                        mainTrener.Show();
                    }
                    else if(currentUserFirstOrDefault.type_user_id == 3)
                    {
                        MessageBox.Show("Вы вошли как косметолог", "авторизация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        var mainCosmetician = new MainMenuCosmetician();
                        mainCosmetician.Show();
                    }
                    else if(currentUserFirstOrDefault.type_user_id == 4)
                    {
                        MessageBox.Show("Вы вошли как клиент", "авторизация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        var mainClient = new MainMenuClient();
                        mainClient.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка входа");
                    }
                    
                    CloseAction();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , ex.HelpLink , MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }

        
        public void ExitCommandClick(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
