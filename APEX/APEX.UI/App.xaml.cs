using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using APEX.UI.Views;
using System.Windows.Navigation;
using APEX.Services.Interfaces;
using APEX.Services.Repositories;
using APEX.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using APEX.UI.Views.Authentication;

namespace APEX.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<LoginView>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(ConfigurationManager.DatabaseConfig.ConnectionString));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<ILocalizationService, LocalizationService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

        }
    }
}
