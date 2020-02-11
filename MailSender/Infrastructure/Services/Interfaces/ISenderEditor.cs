using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;

namespace MailSender.Infrastructure.Services.Interfaces
{
    public interface ISenderEditor
    {
        void Edit(Sender sender);
    }
}
