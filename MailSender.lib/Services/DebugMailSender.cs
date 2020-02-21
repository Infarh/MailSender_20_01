using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class DebugMailSenderService : IMailSenderService
    {
        public IMailSender GetSender(Server Server) => new DebugMailSender(Server);
    }

    public class DebugMailSender : IMailSender
    {
        private readonly Server _Server;

        public DebugMailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipient To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From.Address, To.Address, _Server.Address, _Server.Port, _Server.UseSSL ? "SSL" : "no SSL",
                Mail.Subject, Mail.Body);
        }

        public void Send(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                Send(Message, From, recipient);
        }

        public Task SendAsync(Mail Mail, Sender From, Recipient To)
        {
            Send(Mail, From, To);
            return Task.CompletedTask;
        }

        public Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To, CancellationToken Cancel = default)
        {
            Send(Message, From, To);
            return Task.CompletedTask;
        }

        public void SendParallel(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, recipient));
        }
    }
}