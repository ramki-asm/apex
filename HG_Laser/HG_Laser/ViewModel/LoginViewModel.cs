using System.Windows;
using System.Windows.Input;
using APEX.Common.Helpers;
using HG_Laser.View;
using Microsoft.Extensions.DependencyInjection;

namespace HG_Laser.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
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

        public ICommand LoginCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand MinimizeCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);
            MinimizeCommand = new RelayCommand(ExecuteMinimizeCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (Username == "admin" && Password == "admin")
            {
                var mainView = App.Services.GetRequiredService<MainView>();
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

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteMinimizeCommand(object obj)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginView loginView)
                {
                    loginView.WindowState = WindowState.Minimized;
                    break;
                }
            }
        }
    }
}
