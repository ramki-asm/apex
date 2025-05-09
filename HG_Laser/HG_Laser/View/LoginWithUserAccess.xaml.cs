

using System.Windows.Controls;
using UI.ViewModels;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for LoginWithUserAccess.xaml
    /// </summary>
    public partial class LoginWithUserAccess : UserControl
    {
        public LoginWithUserAccess()
        {
            InitializeComponent();
            DataContext = new LoginWithUserAccessViewModel();
        }
    }
}
