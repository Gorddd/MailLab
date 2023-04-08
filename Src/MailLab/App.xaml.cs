using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            //builder.ConfigureServices((context, services) =>
            //{
            //    string connectionString = context.Configuration.GetConnectionString("DefaultConnection") ?? 
            //        throw new ArgumentNullException("There is no configuration");

            //    services.AddSingleton(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            //});

            host = builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<ConfigViewModel>();
            })
            .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

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
