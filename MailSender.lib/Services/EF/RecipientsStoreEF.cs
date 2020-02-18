using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MailSender.lib.Services.EF
{
    public class RecipientsStoreEF : IRecipientsStore
    {
        private readonly MailSenderDB _db;
        public RecipientsStoreEF(MailSenderDB db) => _db = db;

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public Recipient GetById(int id) => _db.Recipients.FirstOrDefault(r => r.Id == id);

        public int Create(Recipient item)
        {
            _db.Recipients.Add(item);
            SaveChanges();
            return item.Id;
        }

        public void Edit(int id, Recipient item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();
        }

        public Recipient Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return null;
            //_db.Recipients.Remove(db_item);
            _db.Entry(db_item).State = EntityState.Deleted;
            SaveChanges();
            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
