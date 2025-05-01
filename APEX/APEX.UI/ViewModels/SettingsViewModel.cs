using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using APEX.Common.Helpers;
using APEX.Common.Models;
using APEX.Services.Interfaces;

namespace APEX.UI.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ILocalizationService _localizationService;
        private readonly IUserService _userService;

        private User _currentUser;

        public ICommand SaveCommand { get; }

        public SettingsViewModel(
            ILocalizationService localizationService,
            IUserService userService)
        {
            _localizationService = localizationService;
            _userService = userService;

            SaveCommand = new RelayCommand(Save);

            LoadCurrentUser();
        }

        public User CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        private async void LoadCurrentUser()
        {
            // In a real app, you'd get the current user ID from the auth service
            CurrentUser = await _userService.GetUserByIdAsync(1);
        }

        private async void Save()
        {
            await _userService.UpdateUserAsync(CurrentUser);
        }
    }
}
