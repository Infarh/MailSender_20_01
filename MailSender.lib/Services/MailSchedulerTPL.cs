using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class MailSchedulerTPL : IMailScheduler
    {
        private readonly ISchedulerTasksStore _TasksStore;
        private readonly IMailSenderService _MailSenderService;
        private volatile CancellationTokenSource _ProcessTaskCancellation;

        public MailSchedulerTPL(ISchedulerTasksStore TasksStore, IMailSenderService MailSenderService)
        {
            _TasksStore = TasksStore;
            _MailSenderService = MailSenderService;
        }

        public void Start()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancellation, cancellation)?.Cancel();

            var first_task = _TasksStore.GetAll()
               .Where(task => task.Time > DateTime.Now)
               .OrderBy(task => task.Time)
               .FirstOrDefault();
            if (first_task is null) return;

            WaitTaskAsync(first_task, cancellation.Token);
        }

        private async void WaitTaskAsync(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var task_time = task.Time;
            var delta = task_time.Subtract(DateTime.Now);

            if (delta.TotalSeconds > 0)
                await Task.Delay(delta, Cancel).ConfigureAwait(false);
            Cancel.ThrowIfCancellationRequested();

            await ExecuteTask(task, Cancel);
            _TasksStore.Remove(task.Id);

            await Task.Run(Start, Cancel);
        }

        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var sender = _MailSenderService.GetSender(task.Server);
            await sender.SendAsync(task.Mail, task.Sender, task.Recipients.Recipients, Cancel);
        }
    }
}
