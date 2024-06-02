using LobanovaMatvienkoApiHttpClient;
using LobanovaMatvienkoWpfClient.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace LobanovaMatvienkoWpfClient
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
            services.AddHttpClient();
            const string ApiUrl = "http://localhost:5000";
            services.AddSingleton<ClientHttpClient>(sp =>
            {
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                var client = factory.CreateClient();
                var httpClient = new ClientHttpClient(ApiUrl, client);
                return httpClient;
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ClientsViewModel>();

        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

}

}
