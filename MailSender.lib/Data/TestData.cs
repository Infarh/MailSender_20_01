using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server { Id = 0, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server { Id = 1, Name = "Mail.ru", Address = "smtp.mail.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server { Id = 2, Name = "GMail", Address = "smtp.gmail.com", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender { Id = 0, Name = "Иванов", Address = "ivanov@server.ru" },
            new Sender { Id = 1, Name = "Петров", Address = "petrov@server.ru" },
            new Sender { Id = 2, Name = "Сидоров", Address = "sidorov@server.ru" },
        };

        public static List<Recipient> Recipients { get; } = new List<Recipient>
        {
            new Recipient { Id = 0, Name = "Иванов", Address = "ivanov@server.ru" },
            new Recipient { Id = 1, Name = "Петров", Address = "petrov@server.ru" },
            new Recipient { Id = 2, Name = "Сидоров", Address = "sidorov@server.ru" },
        };
    }
}
