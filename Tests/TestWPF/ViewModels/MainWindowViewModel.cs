using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.MVVM;

namespace TestWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Наше новое окно!!!";

        public string Title
        {
            get => _Title;
            //set => Set(ref _Title, value);
            set
            {
                if(Set(ref _Title, value))
                    OnPropertyChanged(nameof(TitleLength));
            }
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    //OnPropertyChanged("Title");
            //    OnPropertyChanged();
            //}
        }

        public int TitleLength => _Title.Length;

        private string _TestValue = "90";

        public string TestValue
        {
            get => _TestValue;
            set => Set(ref _TestValue, value);
        }

        private double _X;
        private double _Y;

        public double X
        {
            get => _X;
            set => Set(ref _X, value);
        }

        public double Y
        {
            get => _X;
            set => Set(ref _X, value);
        }

        #region Property2 : string - Некое свойство

        /// <summary>Некое свойство</summary>
        private string _Property2;

        /// <summary>Некое свойство</summary>
        public string Property2 { get => _Property2; set => Set(ref _Property2, value); }

        #endregion
    }
}
