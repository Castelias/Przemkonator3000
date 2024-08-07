using Przemkonator3000.Models;
using System.Text.RegularExpressions;

namespace Przemkonator3000
{
    public class TextParserService
    {

        public bool TryParseSubject(string subject, out string? serverName, out string? statusChange, out string? statusBefore, out string? statusAfter)
        {
            serverName = null;
            statusChange = null;
            statusBefore = null;
            statusAfter = null;

            string pattern = @":\s*(.*?)\s*(CRIT|WARN|UP|DOWN|OK)\s*->\s*(CRIT|WARN|UP|DOWN|OK)";
            var match = Regex.Match(subject, pattern);

            if (match.Success)
            {
                serverName = match.Groups[1].Value.Trim();
                serverName = TrimTrailingCharacters(serverName, ' ', '-');
                statusChange = $"{match.Groups[2].Value} -> {match.Groups[3].Value}";
                statusBefore = match.Groups[2].Value.Trim();
                statusAfter = match.Groups[3].Value.Trim();
                return true;
            }
            return false;
        }

        public static string TrimTrailingCharacters(string input, params char[] charsToTrim)
        {
            return input.TrimEnd(charsToTrim);
        }

        public static int IndexOfAny(string str, string[] values, int startIndex)
        {
            int minIndex = -1;

            foreach (string value in values)
            {
                int index = str.IndexOf(value, startIndex, StringComparison.Ordinal);
                if (index != -1 && (minIndex == -1 || index < minIndex))
                {
                    minIndex = index;
                }
            }
            return minIndex;
        }

        public Login GetCredentials()
        {
            Console.CursorVisible = false;
            string login = string.Empty;
            string password = string.Empty;
            int currentField = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Use arrow keys to navigate. Press Enter to submit.");

                if (currentField == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("LOGIN:    " + login);
                    Console.ResetColor();
                    Console.WriteLine("PASSWORD: " + new string('*', password.Length));
                }
                else
                {
                    Console.WriteLine("LOGIN:    " + login);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PASSWORD: " + new string('*', password.Length));
                    Console.ResetColor();
                }

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    currentField = (currentField + 1) % 2;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentField == 0 && login.Length > 0)
                    {
                        login = login.Substring(0, login.Length - 1);
                    }
                    else if (currentField == 1 && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                    }
                }
                else if (key.KeyChar != '\u0000' && !char.IsControl(key.KeyChar))
                {
                    if (currentField == 0)
                    {
                        login += key.KeyChar;
                    }
                    else if (currentField == 1)
                    {
                        password += key.KeyChar;
                    }
                }
            }
            return new Login(login, password);
        }

        public void CheckForStatusChange(List<ServerStatus> statuses)
        {
            var goodStatuses = new HashSet<string> { "OK", "UP" };
            var badStatuses = new HashSet<string> { "DOWN", "CRIT", "WARN" };

            foreach (var status in statuses)
            {
                if (goodStatuses.Contains(status.FirstStatus) && badStatuses.Contains(status.SecondStatus))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Server: {status.Name}, Status: {status.FirstStatus} --> {status.SecondStatus} | ( ! Change to {status.SecondStatus} !)");
                    Console.ResetColor();
                }
                else if (badStatuses.Contains(status.FirstStatus) && goodStatuses.Contains(status.SecondStatus))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Server: {status.Name}, Status: {status.FirstStatus} --> {status.SecondStatus} | ( Change to {status.SecondStatus} )");
                    Console.ResetColor();
                }
            }
        }

        public static void CheckForStatusChange2(List<ServerStatus> statuses)
        {
            var goodStatuses = new HashSet<string> { "OK", "UP" };
            var badStatuses = new HashSet<string> { "DOWN", "CRIT", "WARN" };

            foreach (var status in statuses)
            {
                if (goodStatuses.Contains(status.FirstStatus) && badStatuses.Contains(status.SecondStatus))
                {
                    Console.WriteLine($"Server: {status.Name}, Status: {status.FirstStatus} --> {status.SecondStatus} | ( ! Change to {status.SecondStatus} !)");
                }
            }
        }

    }
}
