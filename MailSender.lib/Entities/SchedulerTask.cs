using System;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    /// <summary>Задача планировщика</summary>
    public class SchedulerTask : BaseEntity
    {
        /// <summary>Время выполнения задания</summary>
        public DateTime Time { get; set; }

        /// <summary>Отправитель почты в задании</summary>
        public Sender Sender { get; set; }

        /// <summary>Список получателей писем</summary>
        public MailingList Recipients { get; set; }

        /// <summary>Сервер, через который надо выполнить отправку почты</summary>
        public Server Server { get; set; }

        /// <summary>Письмо, которое требуется разослать</summary>
        public Mail Mail { get; set; }
    }
}