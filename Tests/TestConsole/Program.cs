using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }
    }
}
