using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsManager _RecipientsManager;

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

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        #region Команды

        public ICommand LoadRecipientsDataCommand { get; }

        public ICommand SaveRecipientChangesCommand { get; }

        #endregion

        public MainWindowViewModel(IRecipientsManager RecipientsManager)
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecuted, CanSaveRecipientChangesCommandExecute);

            _RecipientsManager = RecipientsManager;
        }

        private bool CanLoadRecipientsDataCommandExecute() => true;

        private void OnLoadRecipientsDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }

        private bool CanSaveRecipientChangesCommandExecute(Recipient recipient)
        {
            System.Diagnostics.Debug.WriteLine("Проверка состояния команды " + recipient?.Name);
            return recipient != null;
        }

        private void OnSaveRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
    }
}
