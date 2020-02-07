using System.Collections.Generic;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetById(int id);

        int Create(Recipient Recipient);

        void Edit(int id, Recipient Recipient);

        Recipient Remove(int id);

        void SaveChanges();
    }
}