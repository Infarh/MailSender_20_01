using System.Collections.Generic;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> Get();

        void Edit(int id, Recipient Recipient);

        void SaveChanges();
    }
}