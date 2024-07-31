using DevControl.App.Services;
using DevControl.App.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace DevControl.App
{
    internal static class Program
    {
        private static readonly string mutexName = "AppDevControl";

        [STAThread]
        static void Main(string[] args)
        {
            if(args.Contains("/update"))
            {
                UpdateParameters updateParameters = new();
                updateParameters.CheckParameters();
            }

            using Mutex mutex = new(false, mutexName, out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show($"O {AppConfig.AppName} já está em execução!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<WindowMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WindowMain>();
            //services.AddTransient<IMyService, MyService>(); // Registrar outros serviços
        }
    }
}