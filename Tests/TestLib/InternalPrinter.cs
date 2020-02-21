using System;
using System.ComponentModel;

namespace TestLib
{
    [Description("Скрытый принтер")]
    internal class InternalPrinter : Printer
    {
        public InternalPrinter() : base(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ">>") { }

        public override void Print([Description("Печатаемое сообщение скрытого принтера")] string str)
        {
            base.Print(str);
            Console.WriteLine(new string('-', 10));
        }
    }
}