using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientsManager : IRecipientsManager
    {
        private IRecipientsStore _Store;

        public RecipientsManager(IRecipientsStore Store) { _Store = Store; }


        public IEnumerable<Recipient> GetAll()
        {
            return _Store.GetAll();
        }

        public void Add(Recipient NewRecipient)
        {

        }

        public void Edit(Recipient Recipient)
        {
            _Store.Edit(Recipient.Id, Recipient);
        }
        // Delete(Recipient)

        public void SaveChanges()
        {
            _Store.SaveChanges();
        }
    }
}
