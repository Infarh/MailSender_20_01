using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Thread(() => { Console.WriteLine("Печать внутри потока"); }) { IsBackground = true }.Start();

            //Action<string> printer = str => Console.WriteLine("Печать сообщения из потока {0}:{1}", Thread.CurrentThread.ManagedThreadId, str);
            //printer("Message 1");
            //printer.Invoke("Message 2");
            //IAsyncResult result = null;
            //result = printer.BeginInvoke("Message 3", r => printer.EndInvoke(result), null);

            //var worker = new BackgroundWorker();
            //worker.DoWork += (s, e) => { /* Здесь выполняется сама асинхронная операция */ };
            //worker.ProgressChanged += (s, e) => { /* Здесь выполняются действия по изменению UI при изменении прогресса операции */ };
            //worker.RunWorkerCompleted - при завершении операции
            //worker.RunWorkerAsync();


            //Parallel.Invoke(
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod, 
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("Ещё один параллельный вызов"));

            //Parallel.Invoke(
            //    new ParallelOptions { MaxDegreeOfParallelism = 2 },
            //    () => { Console.WriteLine("Действие 1"); },
            //    () => { Console.WriteLine("Действие 2"); },
            //    () => { Console.WriteLine("Действие 3"); }
            //    );

            //Parallel.Invoke(
            //    //new ParallelOptions { MaxDegreeOfParallelism = 3 }, 
            //    Enumerable.Repeat(new Action(ParallelInvokeMethod), 100).ToArray());


            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
