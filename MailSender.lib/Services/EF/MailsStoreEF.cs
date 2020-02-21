using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class MailsStoreEF : StoreEF<Mail>, IMailsStore
    {
        public MailsStoreEF(MailSenderDB db) : base(db) { }

        public override void Edit(int id, Mail item)
        {
            var db_item = GetById(id);
            if(db_item is null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }
}
