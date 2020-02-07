using System.Collections.Generic;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class MailingList : NamedEntity
    {
        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
