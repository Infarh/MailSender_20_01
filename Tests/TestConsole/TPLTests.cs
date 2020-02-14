using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TestConsole
{
    internal static class TPLTests
    {
        public static void Start()
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

            //Parallel.For(0, 100, i => ParallelInvokeMethod($"Message {i}"));
            //Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 3 }, i => ParallelInvokeMethod($"Message {i}"));
            //var for_reslut = Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 16 }, (i, state) =>
            //{
            //    if (i > 15) state.Break();
            //    ParallelInvokeMethod($"Message {i}");
            //});

            //Console.WriteLine("Выполнилось {0} итераций", for_reslut.LowestBreakIteration);

            var messages = Enumerable.Range(1, 300).Select(i => $"Message {i}");//.ToArray();

            //Parallel.ForEach(messages, ParallelInvokeMethod);
            //Parallel.ForEach(messages, s => ParallelInvokeMethod(s));
            //var foreach_result = Parallel.ForEach(messages, (s, state) =>
            //{
            //    if (s.EndsWith("20")) state.Break();
            //    ParallelInvokeMethod(s);
            //});
            //Console.WriteLine("Выполнилось {0} итераций", foreach_result.LowestBreakIteration);

            var cancellation = new CancellationTokenSource(millisecondsDelay: 3000);
            var long_creating_messages = messages
               .AsParallel()
               .WithDegreeOfParallelism(degreeOfParallelism: 3)
               .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
               .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
               .WithCancellation(cancellation.Token)
               .Select(m =>
                {
                    Console.WriteLine("Запрос сообщения {0}", m);
                    Thread.Sleep(250);
                    Console.WriteLine("Сообщение {0} сформировано", m);
                    return m;
                });

            var timer = Stopwatch.StartNew();
            var selected_messages = long_creating_messages
               .Select(m => (msg: m, length: m.Length))
               .AsSequential()
               .Where(m => m.msg.EndsWith("20"))
               .ToArray();
            timer.Stop();
            Console.WriteLine("Данные обработаны за {0}c", timer.Elapsed.TotalSeconds);
        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished", Thread.CurrentThread.ManagedThreadId);
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine("ThrID:{0} - started: {1}", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }
    }
}
