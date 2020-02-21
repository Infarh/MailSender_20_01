using System;
using System.Windows;
using MailSender.Reports;
using Microsoft.Extensions.Configuration;

namespace MailSender
{
    public partial class App
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Environment.CurrentDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
    }
}
