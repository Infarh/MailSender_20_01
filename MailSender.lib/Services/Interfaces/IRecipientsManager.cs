using System.Collections.Generic;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsManager
    {
        IEnumerable<Recipient> GetAll();

        void Add(Recipient NewRecipient);

        void Edit(Recipient Recipient);

        void SaveChanges();
    }
}
