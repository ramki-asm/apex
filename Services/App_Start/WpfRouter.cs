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
            
        }
    }
}