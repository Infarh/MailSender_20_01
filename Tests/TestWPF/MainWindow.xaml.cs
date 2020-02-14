//using TestWPF.ViewModels;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new MainWindowViewModel();
        }

        private void OnStartButtonClick(object Sender, RoutedEventArgs E)
        {
            const string message = "Hello World!";

            var result = GetMessageLength(message);

            ResultRun.Text = result.ToString();
        }

        private void OnCancelButtonClick(object Sender, RoutedEventArgs E)
        {

        }

        private Task<int> GetMessageLengthAsync(string Message, int Timeout = 30)
        {
            return Task.Run(() => GetMessageLength(Message, Timeout));
        }

        private int _StartCount;
        private int GetMessageLength(string Message, int Timeout = 30)
        {
            for(var i = 0; i < 100; i++)
                Thread.Sleep(Timeout);

            return Message.Length + _StartCount++;
        }
    }
}
