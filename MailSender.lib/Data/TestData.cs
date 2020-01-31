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
            new Server { Name = "Яндекс", Address = "smtp.yandex.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server { Name = "Mail.ru", Address = "smtp.mail.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server { Name = "GMail", Address = "smtp.gmail.com", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender { Name = "Иванов", Address = "ivanov@server.ru" },
            new Sender { Name = "Петров", Address = "petrov@server.ru" },
            new Sender { Name = "Сидоров", Address = "sidorov@server.ru" },
        }; 

        public static List<Recipient> Recipients { get; } = new List<Recipient>
        {
            new Recipient { Name = "Иванов", Address = "ivanov@server.ru" },
            new Recipient { Name = "Петров", Address = "petrov@server.ru" },
            new Recipient { Name = "Сидоров", Address = "sidorov@server.ru" },
        };
    }
}
