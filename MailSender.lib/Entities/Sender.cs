using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Sender : PersonEntity
    {
        public override string ToString() => $"{Name}:{Address}";
    }
}
