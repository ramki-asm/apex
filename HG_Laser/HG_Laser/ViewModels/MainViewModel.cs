using APEX.Common.Helpers;
using FontAwesome.Sharp;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _mainFormViewModel;
        private string _caption;
        private IconChar _icon;

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

         
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowSettingViewCommand { get; }
public ICommand ShowDashboardCommand { get; }

      public  MainViewModel()
        {
            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowSettingViewCommand = new ViewModelCommand(ExecuteShowSettingViewCommand);

            ShowDashboardCommand = new ViewModelCommand(ExecuteShowDashboardCommand);
            ExecuteShowHomeViewCommand(null);
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
