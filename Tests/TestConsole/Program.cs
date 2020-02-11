using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток[id:{0}]:{1} - {2}фоновый", thread.ManagedThreadId, thread.Name, thread.IsBackground ? "" : "не ");
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Главный поток";
            CheckThread(Thread.CurrentThread);

           //FirstThreadMethod();
           //var first_thread = new Thread(new ThreadStart(FirstThreadMethod));
           var clock_thread = new Thread(ClockThread);
            clock_thread.Name = "Фоновый потолк";
            clock_thread.Priority = ThreadPriority.BelowNormal;
            clock_thread.IsBackground = true;
            clock_thread.Start();


            Console.WriteLine("Главный поток завершился.");
            Console.ReadLine();
        }

        private static void ClockThread()
        {
            CheckThread(Thread.CurrentThread);
            while (true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }
        }
    }
}
