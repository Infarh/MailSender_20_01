using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestLib
{
    public class Printer
    {
        private string _Prefix;

        public Printer(string Prefix) => _Prefix = Prefix;

        public virtual void Print([Description("Печатаемое сообщение")] string str) => 
            Console.WriteLine("{0}{1}", _Prefix, str);
    }
}
