using Microsoft.Extensions.DependencyInjection;
using UI.View;
using UI.ViewModels;
using System.Windows;
using APEX.Services.Interfaces;
using APEX.Services.Services;  
using Services.Interfaces;
using Services.Services;
using log4net;
using log4net.Config;

namespace UI
{
    public partial class App : Application
    {
        /// <summary>
        /// The purpose of this class is to:
        /// 1. Load startup page.
        /// 2. Setting up Dependency Injection by registering Views, ViewModels, Services and respective dependencies.
        /// 3. Logging the global exception i.e. unhandled exception and prevents application from crash.
        /// </summary>
        public static ServiceProvider Services { get; private set; }
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));
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
            services.AddTransient<AlarmViewModel>();


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
            services.AddScoped<Alarms>(provider => new Alarms
            { DataContext = provider.GetRequiredService<AlarmViewModel>() });
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainView = Services.GetRequiredService<MainView>();
            mainView.Show();
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            Log.Info("Application started");
            // Log unhandled Exception. Don't change this code.
            DispatcherUnhandledException += (s, args) =>
            {
                Log.Error("Unhandled exception", args.Exception);
                // Prevent Application from crash. Dont change, else it will crash the application.
                args.Handled = true;
                MessageBox.Show("An error occurred. Check the log file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          
            };
        }
     
    }
}