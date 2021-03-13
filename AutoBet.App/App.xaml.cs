using AutoBet.App.ViewModels;
using AutoBet.Domain.Entities;
using AutoBet.Domain.Interfaces;
using AutoBet.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AutoBet.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AuthViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<BetfairAuthHandlerService>();

            //services.AddSingleton<INavigator, Navigator>();

            //Services
            services.AddSingleton<CertificateService>();
            services.AddSingleton<MainNavigationService>();
            services.AddHttpClient<IBetfairAuthService,BetfairAuthService>().ConfigurePrimaryHttpMessageHandler<BetfairAuthHandlerService>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = serviceProvider.GetService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
