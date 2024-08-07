using Przemkonator3000.Models;
using MailService = Przemkonator3000.Servvices.MailService;

namespace Przemkonator3000.Menus
{
    public static class RunAppMenu
    {
        private static readonly List<ServerStatus> _messageList = [];
        private static Timer? _timer;
        private static Login? _login;
        private static readonly CancellationTokenSource _cts = new();
        private static readonly MailService _mailService = new();
        private static readonly TextParserService _textParserService = new();

        public static void Run()
        {
            _login = _textParserService.GetCredentials();
            _timer = new Timer(RunApp, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            Console.WriteLine("Press [Enter] to exit the program...");
            Console.ReadLine();
            _cts.Cancel();
            _timer?.Dispose();
        }

        private static async void RunApp(object? state)
        {
            if (_login != null)
            {
                await _mailService.FetchServerStatusAsync(_login, _cts.Token, _messageList);
                _textParserService.CheckForStatusChange(_messageList);
            }
        }     
    }
}
