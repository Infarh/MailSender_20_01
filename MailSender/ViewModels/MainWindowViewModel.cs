using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight;
using MailSender.lib.Entities;
using MailSender.lib.Services;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly RecipientsManager _RecipientsManager;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        public MainWindowViewModel(RecipientsManager RecipientsManager)
        {
            _RecipientsManager = RecipientsManager;

            _Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }
    }
}
