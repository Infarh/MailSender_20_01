using System.Linq;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public class MailsStoreInMemory : DataStoreInMemory<Mail>, IMailsStore
    {
        public MailsStoreInMemory() : base(Enumerable.Range(1, 10).Select(i => new Mail{ Id = i, Subject = $"Message {i}", Body = $"Message body {i}"}).ToList())
        {
            
        }

        public override void Edit(int id, Mail recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            db_recipient.Subject = recipient.Subject;
            db_recipient.Body = recipient.Body;
        }
    }
}