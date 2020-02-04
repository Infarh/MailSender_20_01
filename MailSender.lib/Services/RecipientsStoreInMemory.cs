using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Data;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory
    {
        public IEnumerable<Recipient> Get() => TestData.Recipients;

        
    }
}
