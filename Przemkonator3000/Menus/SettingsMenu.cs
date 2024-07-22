namespace Przemkonator3000.Menus
{
    public static class SettingsMenu
    {
        public static void Run()
        {
            Menu menu = new("Settings: ", [$"ImapPort: {Settings.Instance.ImapPort}", $"SmtpPort: {Settings.Instance.SmtpPort}", $"ImapHost: {Settings.Instance.ImapHost}", $"SmtpHost: {Settings.Instance.SmtpHost}","Default Settings", "Back"]);

            int selectedOption = menu.Run();

            switch (selectedOption)
            {
                case 0:
                    ChangeImapPortMenu.Run();
                    Run();
                    break;
                case 1:
                    ChangeSmtpPortMenu.Run();
                    Run();
                    break;
                case 2:
                    ChangeImapHostMenu.Run();
                    Run();
                    break;
                case 3:
                    ChangeSmtpHostMenu.Run();
                    Run();
                    break;
                case 4:
                    Console.WriteLine($"Default Settings");
                    Settings.Instance.LoadDefaultSettings();
                    Settings.Instance.SaveSettings();
                    Run();
                    break;
                case 5:
                    MainMenu.Run();
                    break;

                default:
                    break;
            }
        }
    }
}