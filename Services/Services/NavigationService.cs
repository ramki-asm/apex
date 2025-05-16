using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
 
using APEX.Services.Interfaces;
 
using static System.Net.Mime.MediaTypeNames;

namespace APEX.Services.Services
{
    public class NavigationService 
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<BindableBase> _navigationStack = new Stack<BindableBase>();

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        //{
        //    var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        //    var viewType = GetViewType(viewModel.GetType());
        //    var view = (Window)_serviceProvider.GetRequiredService(viewType);

        //    view.DataContext = viewModel;
        //    view.Show();

        //    if (_navigationStack.Count > 0)
        //    {
        //        var currentWindow = Application.Current.Windows.OfType<Window>()
        //            .FirstOrDefault(w => w.DataContext == _navigationStack.Peek());
        //        currentWindow?.Close();
        //    }

        //    _navigationStack.Push(viewModel);
        //}

        //public void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModelBase
        //{
        //    var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        //    if (viewModel is IParameterizedViewModel parameterizedViewModel)
        //    {
        //        parameterizedViewModel.Initialize(parameter);
        //    }

        //    var viewType = GetViewType(viewModel.GetType());
        //    var view = (Window)_serviceProvider.GetRequiredService(viewType);

        //    view.DataContext = viewModel;
        //    view.Show();

        //    if (_navigationStack.Count > 0)
        //    {
        //        var currentWindow = Application.Current.Windows.OfType<Window>()
        //            .FirstOrDefault(w => w.DataContext == _navigationStack.Peek());
        //        currentWindow?.Close();
        //    }

        //    _navigationStack.Push(viewModel);
        //}

        public void GoBack()
        {
            //if (_navigationStack.Count <= 1) return;

            //_navigationStack.Pop();
            //var previousViewModel = _navigationStack.Peek();
            //var viewType = GetViewType(previousViewModel.GetType());
            //var view = (Window)_serviceProvider.GetRequiredService(viewType);

            //view.DataContext = previousViewModel;
            //view.Show();

            //var currentWindow = Application.Current.Windows.OfType<Window>()
            //    .FirstOrDefault(w => w.DataContext != previousViewModel);
            //currentWindow?.Close();
        }

        private Type GetViewType(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("ViewModels", "Views").Replace("ViewModel", "View");
            return Assembly.GetExecutingAssembly().GetType(viewName);
        }
    }
}
