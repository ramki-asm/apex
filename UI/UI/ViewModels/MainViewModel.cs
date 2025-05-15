//using APEX.Common.Helpers;
//using FontAwesome.Sharp;
//using System.Windows.Input;
//using UI.ViewModels;

//namespace UI.ViewModels
//{
//    public class MainViewModel : ViewModelBase
//    {
//        private ViewModelBase _mainFormViewModel;
//        private string _caption;
//        private IconChar _icon;

//        public ViewModelBase MainFormViewModel
//        {
//            get => _mainFormViewModel;
//            set
//            {
//                _mainFormViewModel = value;
//                OnPropertyChanged(nameof(MainFormViewModel));
//            }
//        }

//        public string Caption
//        {
//            get => _caption;
//            set
//            {
//                _caption = value;
//                OnPropertyChanged(nameof(Caption));
//            }
//        }

//        public IconChar Icon
//        {
//            get => _icon;
//            set
//            {
//                _icon = value;
//                OnPropertyChanged(nameof(Icon));
//            }
//        }


//        public ICommand ShowHomeViewCommand { get; }
//        public ICommand ShowCustomerViewCommand { get; }
//        public ICommand ShowSettingViewCommand { get; }
//        public ICommand ShowAlarmViewCommand { get; }
//public ICommand ShowDashboardCommand { get; }

//      public  MainViewModel()
//        {
//            // Initialize commands
//            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
//            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
//            ShowSettingViewCommand = new ViewModelCommand(ExecuteShowSettingViewCommand);
//            ShowAlarmViewCommand = new ViewModelCommand(ExecuteShowAlarmViewCommand);
//            ShowDashboardCommand = new ViewModelCommand(ExecuteShowDashboardCommand);
//            ExecuteShowHomeViewCommand(null);
//        }

//        private void ExecuteShowAlarmViewCommand(object obj)
//        {
//            MainFormViewModel = new AlarmViewModel();
//            Caption = "Alarms";
//            Icon = IconChar.Home;
//        }

//        private void ExecuteShowDashboardCommand(object obj)
//        {
//            MainFormViewModel = new DashboardViewModel();
//            Caption = "Dashboard";
//            Icon = IconChar.Home;
//        }

//        private void ExecuteShowHomeViewCommand(object obj)
//        {
//            MainFormViewModel = new HomeViewModel();
//            Caption = "Home";
//            Icon = IconChar.Home;
//        }

//        private void ExecuteShowCustomerViewCommand(object obj)
//        {
//            MainFormViewModel = new CustomerViewModel();
//            Caption = "Customers";
//            Icon = IconChar.UserGroup;
//        }

//        private void ExecuteShowSettingViewCommand(object obj)
//        {
//            MainFormViewModel = new SettingViewModel();
//            Caption = "Settings";
//            Icon = IconChar.Gear;
//        }
//    }
//}
using APEX.Common.Helpers;
using Common.Models;
using FontAwesome.Sharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _mainFormViewModel;
        private string _caption;
        private IconChar _icon;
        private ObservableCollection<MenuButtonConfig> _menuButtons;

        public ViewModelBase MainFormViewModel
        {
            get => _mainFormViewModel;
            set
            {
                _mainFormViewModel = value;
                OnPropertyChanged(nameof(MainFormViewModel));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ObservableCollection<MenuButtonConfig> MenuButtons
        {
            get => _menuButtons;
            set
            {
                _menuButtons = value;
                OnPropertyChanged(nameof(MenuButtons));
            }
        }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowSettingViewCommand { get; }
        public ICommand ShowAlarmViewCommand { get; }
        public ICommand ShowDashboardCommand { get; }

        public MainViewModel()
        {
            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowSettingViewCommand = new ViewModelCommand(ExecuteShowSettingViewCommand);
            ShowAlarmViewCommand = new ViewModelCommand(ExecuteShowAlarmViewCommand);
            ShowDashboardCommand = new ViewModelCommand(ExecuteShowDashboardCommand);

            LoadMenuButtons();

            ExecuteShowHomeViewCommand(null);
        }

        private void LoadMenuButtons()
        {
            try
            {
                // Read the JSON file
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "MenuButtons.json");
                if (!File.Exists(jsonPath))
                {
                    // If the file doesn't exist, initialize an empty collection
                    MenuButtons = new ObservableCollection<MenuButtonConfig>();
                    return;
                }

                string json = File.ReadAllText(jsonPath);
                var allButtons = JsonConvert.DeserializeObject<List<MenuButtonConfig>>(json);

                // Map command strings to actual ICommand properties
                var commandMap = new Dictionary<string, ICommand>
                {
                    { "ShowDashboardCommand", ShowDashboardCommand },
                    { "ShowHomeViewCommand", ShowHomeViewCommand },
                    { "ShowCustomerViewCommand", ShowCustomerViewCommand },
                    { "ShowSettingViewCommand", ShowSettingViewCommand },
                    { "ShowAlarmViewCommand", ShowAlarmViewCommand }
                };

                foreach (var button in allButtons)
                {
                    // Map the Icon string to IconChar
                    if (Enum.TryParse<IconChar>(button.Icon, out var iconChar))
                    {
                        button.Icon = iconChar.ToString(); // Ensure consistency
                    }

                     
                    if (commandMap.TryGetValue(button.CommandName, out var command))
                    {
                        button.Command = command;
                    }
                    else
                    {
                        
                        Console.WriteLine($"Command '{button.CommandName}' not found for button '{button.Text}'.");
                    }
                }

                // Filter buttons based on configuration
                MenuButtons = new ObservableCollection<MenuButtonConfig>(allButtons.Where(button =>
                    button.IsDefault || ShouldShowButton(button)));
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., log the error, show a message)
                Console.WriteLine($"Error loading menu buttons: {ex.Message}");
                MenuButtons = new ObservableCollection<MenuButtonConfig>();
            }
        }

        private bool ShouldShowButton(MenuButtonConfig button)
        {

            return (button.IsChecked && button.IsDefault);
 
        }

        private void ExecuteShowAlarmViewCommand(object obj)
        {
            MainFormViewModel = new AlarmViewModel();
            Caption = "Alarms";
            Icon = IconChar.Home;
        }

        private void ExecuteShowDashboardCommand(object obj)
        {
            MainFormViewModel = new DashboardViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            MainFormViewModel = new HomeViewModel();
            Caption = "Home";
            Icon = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            MainFormViewModel = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowSettingViewCommand(object obj)
        {
            MainFormViewModel = new SettingViewModel();
            Caption = "Settings";
            Icon = IconChar.Gear;
        }
    }
}
