using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MailSender
{
    class Program
    {
        private static readonly IHost __Host;

        static Program()
        {
            __Host = Host.CreateDefaultBuilder()
               .ConfigureServices((c, s) => ConfigureServices(c.Configuration, s))
               .Build();
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            //// ...
            //services.AddSingleton<MainWindow>();
        }

        [STAThread]
        public static void Main()
        {
            __Host.Start();

            App app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
