using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var message_subject = $"Тестовое сообщение от {DateTime.Now}";
            var message_body = $"Тело сообщения - {DateTime.Now}";

            const string from = "shmachilin@yandex.ru";
            const string to = "shmachilin@gmail.com";

            try
            {
                using (var message = new MailMessage(from, to))
                {
                    message.Subject = message_subject;
                    message.Body = message_body;


                    const string server_address = "smtp.yandex.ru";
                    const int server_port = 25; //25
                    using (var client = new SmtpClient(server_address, server_port))
                    {
                        client.EnableSsl = true;

                        var user_name = UserNameEdit.Text;
                        //var user_password = PasswordEdit.Password;
                        SecureString user_password = PasswordEdit.SecurePassword;

                        client.Credentials = new NetworkCredential(user_name, user_password);

                        client.Send(message);

                        MessageBox.Show("Почта отправлена!", "Ура!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
