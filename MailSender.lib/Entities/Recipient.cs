using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Entities
{
    public class Recipient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
