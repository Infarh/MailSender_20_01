using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public class RecipientsStoreInMemory : IRecipientsStore
    {
        public IEnumerable<Recipient> GetAll() => TestData.Recipients;

        public Recipient GetById(int id) => TestData.Recipients.FirstOrDefault(r => r.Id == id);

        public int Create(Recipient Recipient)
        {
            if (TestData.Recipients.Contains(Recipient)) return Recipient.Id;
            Recipient.Id = TestData.Recipients.Count == 0
                ? 1
                : TestData.Recipients.Max(r => r.Id) + 1;
            TestData.Recipients.Add(Recipient);
            return Recipient.Id;
        }

        public void Edit(int id, Recipient recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;       // Притворяемся, что мы работаем не с объектами в памяти, а с объектам в БД
            db_recipient.Address = recipient.Address;
        }

        public Recipient Remove(int id)
        {
            var db_recipient = GetById(id);
            if (db_recipient != null)
                TestData.Recipients.Remove(db_recipient);
            return db_recipient;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище получателей писем.");
            // Так как это хранилище данных в памяти, то здесь ничего не делаем
        }
    }
}
