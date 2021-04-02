using AutoBet.App.Extensions;
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
        public static ServiceProvider Container;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Container = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddViewModels();
            services.AddAutoMapper();

            services.AddSingleton<BetfairAuthHandlerService>();
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddSingleton<ICertificateService, CertificateService>();
            services.AddHttpClient<IBetfairAuthService,BetfairAuthService>().ConfigurePrimaryHttpMessageHandler<BetfairAuthHandlerService>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = Container.GetService<MainWindow>();
            mainWindow.DataContext = Container.GetService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
