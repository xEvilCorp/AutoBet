using AutoBet.Domain.Interfaces;
using AutoBet.Domain.ViewModels;
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
        public static ServiceProvider container;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            container = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddSingleton<MainWindow>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AuthViewModel>();
            services.AddSingleton<CertificateViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<BetfairAuthHandlerService>();

            //Services
            services.AddSingleton<CertificateService>();
            services.AddHttpClient<IBetfairAuthService,BetfairAuthService>().ConfigurePrimaryHttpMessageHandler<BetfairAuthHandlerService>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = container.GetService<MainWindow>();
            mainWindow.DataContext = container.GetService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
