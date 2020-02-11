using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public class SendersStoreInMemory : DataStoreInMemory<Sender>, ISendersStore
    {
        public SendersStoreInMemory() : base(TestData.Senders) { }

        public override void Edit(int id, Sender sender)
        {
            var db_sender = GetById(id);
            if (db_sender is null) return;

            db_sender.Name = sender.Name;
            db_sender.Address = sender.Address;
        }
    }
}