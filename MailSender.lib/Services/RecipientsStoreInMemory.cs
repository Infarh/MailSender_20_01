using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory : IRecipientsStore
    {
        public IEnumerable<Recipient> Get() => TestData.Recipients;

        public void Edit(int id, Recipient recipient)
        {
            // Так как это хранилище данных в памяти, то здесь ничего не делаем
        }

        public void SaveChanges()
        {
            // Так как это хранилище данных в памяти, то здесь ничего не делаем
        }
    }
}
