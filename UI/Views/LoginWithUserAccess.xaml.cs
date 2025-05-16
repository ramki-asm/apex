

using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels;
 
namespace UI.Views
{
    /// <summary>
    /// Interaction logic for LoginWithUserAccess.xaml
    /// </summary>
    public partial class LoginWithUserAccess : UserControl
    {
        public LoginWithUserAccess()
        {
            InitializeComponent();
         DataContext = new SettingsViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (1 == 1)
            {
                var mainView = new SettingsControl();
                mainView.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

        //private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        //{

        //    if(1==1)
        //    {
        //        var mainView = new SettingsControl();
        //        mainView.Show();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    
}
