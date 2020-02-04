using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
