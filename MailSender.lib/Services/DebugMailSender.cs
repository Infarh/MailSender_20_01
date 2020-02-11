﻿using System.Diagnostics;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class DebugMailSender
    {
        private readonly Server _Server;

        public DebugMailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipient To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From.Address, To.Address, _Server.Address, _Server.Port, _Server.UseSSL ? "SSL" : "no SSL",
                Mail.Subject, Mail.Body);
        }
    }
}