using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace APEX.Services.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        void GoBack();
    }
}
