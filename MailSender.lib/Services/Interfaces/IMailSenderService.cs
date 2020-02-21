using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IMailSenderService
    {
        IMailSender GetSender(Server Server);
    }

    public interface IMailSender
    {
        void Send(Mail Mail, Sender From, Recipient To);

        void Send(Mail Message, Sender From, IEnumerable<Recipient> To);

        Task SendAsync(Mail Mail, Sender From, Recipient To);

        Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To, CancellationToken Cancel = default);
    }
}
