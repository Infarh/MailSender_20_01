using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    /// <summary>Почтовый сервер</summary>
    public class Server : NamedEntity
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; } = true;

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
