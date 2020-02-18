using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        public DbSet<Mail> Mails { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<MailingList> MailingLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public MailSenderDB(DbContextOptions<MailSenderDB> opt) : base(opt) { }
    }
}
