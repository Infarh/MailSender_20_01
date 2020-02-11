using System.Net;
using System.Net.Mail;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly Server _Server;

        public MailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Address, From.Name), new MailAddress(To.Address, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using(var client = new SmtpClient(_Server.Address, _Server.Port) { EnableSsl = _Server.UseSSL, Credentials = login })
                    client.Send(message);
            }
        }
    }
}
