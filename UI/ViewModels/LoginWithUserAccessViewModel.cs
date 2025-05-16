using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
 
using UI.Views;

namespace UI.ViewModels
{
    public class LoginWithUserAccessViewModel :BindableBase
    {
        private DelegateCommand<Object> _loginComman;
        public LoginWithUserAccessViewModel()
        {
            _loginComman = new DelegateCommand<Object>(LoginToSettings);
        }

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set=> SetProperty(ref _username, value);    
        }

        public string Password
        {
            get => _password;
            set=> SetProperty(ref _password, value);
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
