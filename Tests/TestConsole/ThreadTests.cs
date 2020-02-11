using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestConsole
{
    internal static class ThreadTests
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток[id:{0}]:{1} - {2}фоновый", thread.ManagedThreadId, thread.Name, thread.IsBackground ? "" : "не ");
        }

        public static void Start()
        {
            Thread.CurrentThread.Name = "Главный поток";
            CheckThread(Thread.CurrentThread);

            //FirstThreadMethod();
            //var first_thread = new Thread(new ThreadStart(FirstThreadMethod));
            var clock_thread = new Thread(ClockThread);
            clock_thread.Name = "Фоновый потолк";
            clock_thread.Priority = ThreadPriority.BelowNormal;
            //clock_thread.IsBackground = true;
            clock_thread.Start();

            var message = "Hello World!";

            //var printer1_thread = new Thread(new ParameterizedThreadStart(PrinterThread));
            //var printer1_thread = new Thread(PrinterThread);
            //printer1_thread.Start(message);

            //var printer2_thread = new Thread(() => PrinterThread(message));
            //printer2_thread.Start();

            var printer_data = new PrinterData(message);
            var printer3_thread = new Thread(printer_data.Print);
            printer3_thread.Start();


            Console.WriteLine("Главный поток завершился.");
            Console.ReadLine();

            //Interlocked.Exchange(ref _ClockCanWork, false);
            _ClockCanWork = false;
            //clock_thread.Abort();
            if (!clock_thread.Join(50))
                clock_thread.Interrupt();
        }

        private class PrinterData
        {
            private string _Message;

            public PrinterData(string Message) => _Message = Message;

            public void Print() =>
                Console.WriteLine("Печать сообщения из потока id:{0} - {1}", Thread.CurrentThread.ManagedThreadId, _Message);
        }

        private static bool _ClockCanWork = true;

        private static void ClockThread()
        {
            try
            {
                CheckThread(Thread.CurrentThread);
                while (_ClockCanWork)
                {
                    Console.Title = DateTime.Now.ToString();
                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван");
            }
            Console.WriteLine("Поток часов завершил свою работу");
        }

        private static void PrinterThread(object parameter)
        {
            PrinterThread((string)parameter);
        }

        private static void PrinterThread(string Message)
        {
            Console.WriteLine("Печать сообщения из потока id:{0} - {1}", Thread.CurrentThread.ManagedThreadId, Message);
            Thread.Sleep(2000);
            Console.WriteLine("Печать сообщения из потока id:{0} - {1} -  завершена", Thread.CurrentThread.ManagedThreadId, Message);
        }
    }
}
