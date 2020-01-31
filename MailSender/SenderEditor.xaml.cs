using System.Windows;
using MailSender.lib.Entities;

namespace MailSender
{
    public partial class SenderEditor
    {
        private MainWindow _MainWindow;

        public string NameValue { get => NameEditor.Text; set => NameEditor.Text = value; }
        public string AddressValue { get => AddressEditor.Text; set => AddressEditor.Text = value; }

        public SenderEditor(Sender Sender, MainWindow MainWindow)
        {
            InitializeComponent();
            NameValue = Sender.Name;
            AddressValue = Sender.Address;
            _MainWindow = MainWindow;
        }

        private void OnOkButtonClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = false;
            Close();
        }

        private void OnCloseMainWindowClick(object Sender, RoutedEventArgs E)
        {
            _MainWindow.Title += "Hello World!";
        }
    }
}
