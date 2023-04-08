using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.EfCode;
using Model.Services;
using Model.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace MailLab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("DefaultConnection") ??
                    throw new ArgumentNullException("There is no configuration");

                services.AddDbContext<EfCoreContext>(options => options.UseSqlite(connectionString));
            });

            host = builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<MigrateService>();
                services.AddTransient<IConfigService, ConfigService>();
                services.AddTransient<ConfigViewModel>();
            })
            .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            host.Start();

            var migrateService = host.Services.GetRequiredService<MigrateService>();
            await migrateService.MigrateAsync();

            MainWindow = host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }
    }
}
