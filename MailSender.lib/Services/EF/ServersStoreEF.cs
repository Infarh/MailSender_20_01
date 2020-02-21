using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class ServersStoreEF : StoreEF<Server>, IServersStore
    {
        public ServersStoreEF(MailSenderDB db) : base(db) { }

        public override void Edit(int id, Server item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Port = item.Port;
            db_item.UseSSL = item.UseSSL;
            db_item.Login = item.Login;
            db_item.Password = item.Password;
        }
    }
}
