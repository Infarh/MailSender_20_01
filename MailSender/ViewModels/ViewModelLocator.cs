using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure.Services;
using MailSender.Infrastructure.Services.Interfaces;
using MailSender.lib.Data.EF;
using MailSender.lib.Services;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MailSender.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            var services = SimpleIoc.Default;

            services.Register(() => App.Configuration);

            services.Register<MainWindowViewModel>();

            services.Register<IRecipientsManager, RecipientsManager>();

            //services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<IRecipientsStore, RecipientsStoreEF>();
            services.Register<ISendersStore, SendersStoreInMemory>();
            services.Register<IServersStore, ServersStoreInMemory>();
            services.Register<IMailsStore, MailsStoreInMemory>();

            services.Register<ISenderEditor, WindowSenderEditor>();

            services.Register<MailSenderDB>();
            services.Register(() => new DbContextOptionsBuilder<MailSenderDB>()
               .UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);
            services.Register<MailSenderDBInitializer>();

            var db_initializer = (MailSenderDBInitializer) services.GetService(typeof(MailSenderDBInitializer));
            var initialize_task = Task.Run(() => db_initializer.InitializeAsync());  // Уходим от удара граблей в следующей строке ниже!!!
            initialize_task.Wait();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
