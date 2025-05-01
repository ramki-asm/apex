using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using APEX.Common.Helpers;
using APEX.Services.Interfaces;
using APEX.UI.ViewModels.APEX.UI.ViewModels.Home;
using APEX.UI.ViewModels.Shared;
using ViewModelBase = APEX.UI.ViewModels.Shared.ViewModelBase;

namespace APEX.UI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private readonly INavigationService _navigationService;
        private readonly ILocalizationService _localizationService;

        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isBusy;

        public ICommand LoginCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        public LoginViewModel(
            IAuthenticationService authService,
            INavigationService navigationService,
            ILocalizationService localizationService)
        {
            _authService = authService;
            _navigationService = navigationService;
            _localizationService = localizationService;

            LoginCommand = new RelayCommand(Login, CanLogin);
            ChangeLanguageCommand = new RelayCommand<string>(ChangeLanguage);
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value    ;
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => _errorMessage = value;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy=value;
        }

        private async void Login()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                //var result = await _authService.AuthenticateAsync(Username, Password);
                //if (result.IsSuccess)
                //{
                //    _navigationService.NavigateTo<HomeViewModel>();
                //}
                //else
                //{
                //    ErrorMessage = _localizationService[result.ErrorMessage] ?? result.ErrorMessage;
                //}
            }
            catch (Exception ex)
            {
                ErrorMessage = _localizationService["LoginError"];
                // Log error
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) &&
                                 !string.IsNullOrWhiteSpace(Password) &&
                                 !IsBusy;

        private void ChangeLanguage(string languageCode)
        {
            _localizationService.CurrentCulture = new CultureInfo(languageCode);
        }
    }
}

