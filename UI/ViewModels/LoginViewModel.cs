using System;
using System.Windows;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using UI.Views; 
using Microsoft.Extensions.DependencyInjection;
using log4net;
 

namespace UI.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand<object> LoginCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand MinimizeCommand { get; }

        public LoginViewModel()
        {
            // Use DelegateCommand<object> for commands with object parameter
            LoginCommand = new DelegateCommand<object>(ExecuteLoginCommand, CanExecuteLoginCommand)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Password); // Auto-requery when properties change
            CloseCommand = new DelegateCommand(ExecuteCloseCommand);
            MinimizeCommand = new DelegateCommand(ExecuteMinimizeCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (Username == "admin" && Password == "admin")
            {
                try
                {
                    var mainView = App.Services.GetRequiredService<MainView>();
                     
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is LoginView loginView)
                        {
                            loginView.Close();
                            break;
                        }
                    }
                    Log.Info("Login Successful!");
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to open MainView", ex);
                    MessageBox.Show("Error opening main window", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Log.Error("Login Failed");
            }
        }

        private void ExecuteCloseCommand()
        {
            Log.Info("Application Closed");
            Application.Current.Shutdown();
        }

        private void ExecuteMinimizeCommand()
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