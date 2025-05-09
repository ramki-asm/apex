using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using APEX.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using UI.View;

namespace UI.ViewModels
{
    public class LoginWithUserAccessViewModel :ViewModelBase
    {
        private ICommand _loginComman;
        public LoginWithUserAccessViewModel()
        {
            _loginComman = new RelayCommand(LoginToSettings);
        }

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private void LoginToSettings(object obj)
        {

            if (Username == "Administrator" && Password == "admin")
            {
                var mainView = App.Services.GetRequiredService<SettingsControl>();
                mainView.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginView)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
