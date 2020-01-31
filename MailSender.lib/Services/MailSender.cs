using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSSL;
        private string _Login;
        private string _Password;

        public MailSender(string ServerAddress, int Port, bool UseSSL, string Login, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSSL = UseSSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(string Subject, string Body, string From, string To)
        {
            using (var message = new MailMessage(From, To))
            {
                message.Subject = Subject;
                message.Body = Body;

                var login = new NetworkCredential(_Login, _Password);
                using(var client = new SmtpClient(_ServerAddress, _Port) { EnableSsl = _UseSSL, Credentials = login })
                    client.Send(message);
            }
        }
    }

    public class DebugMailSender
    {
        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSSL;
        private string _Login;
        private string _Password;

        public DebugMailSender(string ServerAddress, int Port, bool UseSSL, string Login, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSSL = UseSSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(string Subject, string Body, string From, string To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From, To, _ServerAddress, _Port, _UseSSL ? "SSL" : "no SSL", 
                Subject, Body);
        }
    }
}
