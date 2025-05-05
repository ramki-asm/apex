using Microsoft.Extensions.DependencyInjection;
using HG_Laser.View;
using HG_Laser.ViewModel;
using System.Windows;

namespace HG_Laser
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
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<MainViewModel>();

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
            var loginView = Services.GetRequiredService<LoginView>();  
            loginView.Show();
        }
    }
}
