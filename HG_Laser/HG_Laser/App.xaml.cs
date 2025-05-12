using Microsoft.Extensions.DependencyInjection;
using UI.View;
using UI.ViewModels;
using System.Windows;
using APEX.Services.Interfaces;
using APEX.Services.Services;  
using Services.Interfaces;
using Services.Services;

namespace UI
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<SettingsViewModel>();
           
            // Services
            services.AddSingleton<ISerialPortService,SerialPortService>(); 
            services.AddSingleton<ITcpIpService, TcpIpService>();
            //services.AddSingleton<IUsbService, UsbService>();
            services.AddSingleton<ILocalizationService, LocalizationService>();

            // Views
            services.AddTransient<LoginView>(provider => new LoginView
            {
                DataContext = provider.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<MainView>(provider => new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginView = Services.GetRequiredService<MainView>();
            loginView.Show();
        }
    }
}