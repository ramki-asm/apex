using Common.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainViewModel));
        private BindableBase _mainFormViewModel;
        private string _caption;
        private ObservableCollection<MenuButtonConfig> _menuButtons;

        public BindableBase MainFormViewModel
        {
            get => _mainFormViewModel;
            set => SetProperty(ref _mainFormViewModel, value);
        }

        public string Caption
        {
            get => _caption;
            set => SetProperty(ref _caption, value);
        }

        public ObservableCollection<MenuButtonConfig> MenuButtons
        {
            get => _menuButtons;
            set => SetProperty(ref _menuButtons, value);
        }

        public DelegateCommand<object> ShowHomeViewCommand { get; }
        public DelegateCommand<object> ShowCustomerViewCommand { get; }
        public DelegateCommand<object> ShowSettingViewCommand { get; }
        public DelegateCommand<object> ShowAlarmViewCommand { get; }
        public DelegateCommand<object> ShowDashboardCommand { get; }
        public DelegateCommand<object> ShowUserViewCommand { get; }

        public MainViewModel()
        {
            Log.Info("MainViewModel constructor called");
            ShowHomeViewCommand = new DelegateCommand<object>(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new DelegateCommand<object>(ExecuteShowCustomerViewCommand);
            ShowSettingViewCommand = new DelegateCommand<object>(ExecuteShowSettingViewCommand);
            ShowAlarmViewCommand = new DelegateCommand<object>(ExecuteShowAlarmViewCommand);
            ShowDashboardCommand = new DelegateCommand<object>(ExecuteShowDashboardCommand);
            ShowUserViewCommand = new DelegateCommand<object>(ExecuteShowUserViewCommand);

            LoadMenuButtons();
            ExecuteShowHomeViewCommand(null); // Set default view
        }

        private void LoadMenuButtons()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "MenuButtons.json");
                if (!File.Exists(jsonPath))
                {
                    Log.Warn($"MenuButtons.json not found at {jsonPath}");
                    MenuButtons = new ObservableCollection<MenuButtonConfig>();
                    return;
                }

                string json = File.ReadAllText(jsonPath);
                var allButtons = JsonConvert.DeserializeObject<List<MenuButtonConfig>>(json);

                var commandMap = new Dictionary<string, ICommand>
                {
                    { "ShowDashboardCommand", ShowDashboardCommand },
                    { "ShowHomeViewCommand", ShowHomeViewCommand },
                    { "ShowCustomerViewCommand", ShowCustomerViewCommand },
                    { "ShowSettingViewCommand", ShowSettingViewCommand },
                    { "ShowAlarmViewCommand", ShowAlarmViewCommand },
                    { "ShowUserViewCommand", ShowUserViewCommand }
                };

                foreach (var button in allButtons)
                {
                    if (commandMap.TryGetValue(button.CommandName, out var command))
                    {
                        button.Command = command;
                    }
                    else
                    {
                        Log.Warn($"Command '{button.CommandName}' not found for button '{button.Text}'.");
                    }
                }

                MenuButtons = new ObservableCollection<MenuButtonConfig>(allButtons.Where(ShouldShowButton));
            }
            catch (Exception ex)
            {
                Log.Error("Error loading menu buttons", ex);
                MenuButtons = new ObservableCollection<MenuButtonConfig>();
            }
        }

        private bool ShouldShowButton(MenuButtonConfig button)
        {
            Log.Info($"Checking visibility for button: {button.Text}");
            return button.IsVisible;
        }

        private void ExecuteShowAlarmViewCommand(object obj)
        {
            MainFormViewModel = new AlarmViewModel();
            Caption = "Alarms";
        }

        private void ExecuteShowDashboardCommand(object obj)
        {
            MainFormViewModel = new DashboardViewModel();
            Caption = "Dashboard";
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            MainFormViewModel = new HomeViewModel();
            Caption = "Home";
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            MainFormViewModel = new CustomerViewModel();
            Caption = "Customers";
        }

        private void ExecuteShowSettingViewCommand(object obj)
        {
            MainFormViewModel = new SettingViewModel();
            Caption = "Settings";
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            MainFormViewModel = new UserViewModel();
            Caption = "Users";
        }
    }
}