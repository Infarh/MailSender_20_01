using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            //ThreadPoolTests.Start();
            SynchronizationTests.Start();

            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }
    }
}
