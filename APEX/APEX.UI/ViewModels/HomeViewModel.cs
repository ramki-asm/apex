using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using APEX.Common.Helpers;
using APEX.Common.Models;
using APEX.Services.Interfaces;
using APEX.UI.ViewModels.Shared;
using ViewModelBase = APEX.UI.ViewModels.Shared.ViewModelBase;

namespace APEX.UI.ViewModels
{
    // APEX.UI/ViewModels/Home/HomeViewModel.cs
    namespace APEX.UI.ViewModels.Home
    {
        public class HomeViewModel : ViewModelBase
        {
            private readonly INavigationService _navigationService;
            private readonly ILocalizationService _localizationService;
            private readonly IAuthenticationService _authService;

            private ObservableCollection<NavigationItem> _navigationItems;
            private ViewModelBase _currentContent;
            private NavigationItem _selectedNavigationItem;

            public ICommand NavigateCommand { get; }
            public ICommand LogoutCommand { get; }

            public HomeViewModel(
                INavigationService navigationService,
                ILocalizationService localizationService,
                IAuthenticationService authService)
            {
                _navigationService = navigationService;
                _localizationService = localizationService;
                _authService = authService;

                NavigateCommand = new RelayCommand<NavigationItem>(Navigate);
                LogoutCommand = new RelayCommand(Logout);

                InitializeNavigationItems();
            }

            public ObservableCollection<NavigationItem> NavigationItems
            {
                get => _navigationItems;
                set => SetProperty(ref _navigationItems, value);
            }

            public ViewModelBase CurrentContent
            {
                get => _currentContent;
                set => SetProperty(ref _currentContent, value);
            }

            public NavigationItem SelectedNavigationItem
            {
                get => _selectedNavigationItem;
                set => SetProperty(ref _selectedNavigationItem, value);
            }

            private void InitializeNavigationItems()
            {
                NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem
                {
                    Title = _localizationService["Dashboard"],
                    Icon = "Dashboard",
                    ViewModelType = typeof(DashboardViewModel),
                    Order = 1
                },
                new NavigationItem
                {
                    Title = _localizationService["Reports"],
                    Icon = "Report",
                    ViewModelType = typeof(ReportsViewModel),
                    Order = 2
                },
                new NavigationItem
                {
                    Title = _localizationService["Settings"],
                    Icon = "Settings",
                    ViewModelType = typeof(SettingsViewModel),
                    Order = 3,
                    RequiredPermission = "ManageSettings"
                }
            };

                // Order by the Order property
                NavigationItems = new ObservableCollection<NavigationItem>(NavigationItems.OrderBy(ni => ni.Order));

                // Set initial content
                SelectedNavigationItem = NavigationItems.FirstOrDefault();
                if (SelectedNavigationItem != null)
                {
                    Navigate(SelectedNavigationItem);
                }
            }

            private void Navigate(NavigationItem item)
            {
                if (item == null) return;

                if (!string.IsNullOrEmpty(item.RequiredPermission) &&
                    !_authService.HasPermissionAsync(item.RequiredPermission).GetAwaiter().GetResult())
                {
                    // Show access denied message
                    return;
                }

                SelectedNavigationItem = item;
               // CurrentContent = (ViewModelBase)_serviceProvider.GetRequiredService(item.ViewModelType);
            }

            private void Logout()
            {
                _authService.LogoutAsync().GetAwaiter().GetResult();
             //   _navigationService.NavigateTo<LoginViewModel>();
            }
        }
    }
}
