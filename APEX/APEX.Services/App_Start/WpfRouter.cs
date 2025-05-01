using System;
using System.Collections.Generic;

namespace Services
{
    public class WpfRouter
    {
        private readonly Dictionary<string, Type> _routes = new Dictionary<string, Type>();
        private readonly IServiceProvider _serviceProvider;

        public WpfRouter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void RegisterRoute(string route, Type viewModelType)
        {
            _routes[route] = viewModelType;
        }

        public void Navigate(string route)
        {
            if (_routes.TryGetValue(route, out var viewModelType))
            {
                var viewModel = _serviceProvider.GetService(viewModelType);
                // Your navigation logic here
            }
        }
    }
}