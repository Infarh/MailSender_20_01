using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestConsole
{
    internal static class SynchronizationTests
    {
        public static void Start()
        {
            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                var i0 = i;
                threads[i] = new Thread(() => Printer($"Message {i0}"));
            }

            Array.ForEach(threads, thread => thread.Start());
        }

        private static void Printer(string Message, int Count = 20)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                Console.Write(" - msg({0}):", i);
                Console.WriteLine("\"{0}\"", Message);
            }
        }
    }
}
