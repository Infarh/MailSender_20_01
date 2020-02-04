using System.Windows;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //SendersList.ItemsSource = TestData.Senders;
        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs E)
        {
            //var recipient = RecipientsList.SelectedItem as Recipient;
            //var sender = SendersList.SelectedItem as Sender;
            //var server = ServersList.SelectedItem as Server;

            //if(recipient is null || server is null || sender is null) return;

            //var mail_sender = new lib.Services.DebugMailSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password.Decode(3));

            //mail_sender.Send(MailHeader.Text, MailBody.Text, sender.Address, recipient.Address);
        }

        private void OnSenderEditClick(object Sender, RoutedEventArgs E)
        {
            var sender = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            var dialog = new SenderEditor(sender, this);

            if(dialog.ShowDialog() != true) return;

            sender.Name = dialog.NameValue;
            sender.Address = dialog.AddressValue;
        }
    }
}
