using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Mail : BaseEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        //public ICollection Attachments { get; set; } = new List<MailAttachment>();
    }

    //public class MailAttachment : BaseEntity
    //{
    //    // ...
    //}
}