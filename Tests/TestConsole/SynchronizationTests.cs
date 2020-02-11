using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace TestConsole
{
    internal static class SynchronizationTests
    {
        public static void Start()
        {
            //var threads = new Thread[10];

            //for (var i = 0; i < threads.Length; i++)
            //{
            //    var i0 = i;
            //    threads[i] = new Thread(() => Printer3($"Message {i0}"));
            //}

            //Array.ForEach(threads, thread => thread.Start());

            //Mutex mutex = new Mutex(true, "Имя мютекса");
            //mutex.WaitOne();
            //mutex.Close();
            //mutex.ReleaseMutex();

            //var semaphore = new Semaphore(0, 5, "Имя");
            //semaphore.WaitOne();
            //semaphore.Release();

            //var manual_even = new ManualResetEvent(false);
            //var auto_event = new AutoResetEvent(false);

            //var test_threads = Enumerable.Range(0, 5)
            //   .Select(i => new Thread(
            //        () =>
            //        {
            //            Console.WriteLine("Поток {0} стартовал и ожидает разрешения на выполнение задачи", Thread.CurrentThread.ManagedThreadId);
            //            manual_even.WaitOne();
            //            Console.WriteLine("Поток {0} выполнил задачу", Thread.CurrentThread.ManagedThreadId);
            //            manual_even.Reset();
            //        }))
            //   .ToArray();
            //Array.ForEach(test_threads, thread => thread.Start());

            //Console.ReadLine();
            //manual_even.Set();

            //Console.ReadLine();
            //manual_even.Set();

            //Console.ReadLine();
            //manual_even.Set();
        }

        private static readonly object __SyncRoot = new object();

        private static void Printer(string Message, int Count = 20)
        {
            for (var i = 0; i < Count; i++)
            {
                lock (__SyncRoot)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", Message);
                }
            }
        }

        private static void Printer2(string Message, int Count = 20)
        {
            for (var i = 0; i < Count; i++)
            {
                Monitor.Enter(__SyncRoot);
                try
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", Message);
                }
                finally
                {
                    Monitor.Exit(__SyncRoot);
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void Printer3(string Message, int Count = 20)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                Console.Write(" - msg({0}):", i);
                Console.WriteLine("\"{0}\"", Message);
            }
            //Thread.SpinWait(100000);
        }
    }

    ////[Synchronization]
    //internal class Logger : ContextBoundObject
    //{
    //    private string _FilePath;

    //    public string FilePath
    //    {
    //        get => _FilePath;
    //        set
    //        {
    //            if (!File.Exists(value))
    //                throw new FileNotFoundException("Файл не найден", value);
    //            _FilePath = value;
    //        }
    //    }

    //    public Logger(string Path) => _FilePath = Path;

    //    //[MethodImpl(MethodImplOptions.Synchronized)]
    //    public void Log(string Message)
    //    {
    //        //lock (this)
    //        File.AppendAllText(_FilePath, Message);
    //    }
    //}
}
