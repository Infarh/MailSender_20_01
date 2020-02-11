using System;
using System.ComponentModel;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Recipient : PersonEntity, IDataErrorInfo
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if(value == "Иванов321")
                    throw new ArgumentException("Иванов321 нам не подходит", nameof(value));
                //Debug.Assert(value != "Иванов---");
                //Trace.WriteLine("Сообщение в журнал!");
                base.Name = value;
            }
        }

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    default: return null;

                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Пустая ссылка на имя";
                        if (name.Length < 2) return "Имя должно быть длиннее двух символов";
                        if (name.Length > 20) return "Длина имени должна быть не больше 20 символов";

                        return null;
                }
            }
        }

        string IDataErrorInfo.Error => null;
    }
}
