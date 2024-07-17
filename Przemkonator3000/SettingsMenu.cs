namespace Przemkonator3000
{ 
    public static class SettingsMenu
    {
   

    public static void Run()
        {
            Menu menu = new Menu("Settings: ", [$"ImapPort: {Settings.ImapPort}", $"SmtpPort: {Settings.SmtpPort}", $"ImapHost: {Settings.ImapHost}", $"SmtpHost: {Settings.SmtpHost}", "Back"]);

            int selectedOption = menu.Run();

            switch (selectedOption)
            {
                case 0:
                    Console.WriteLine($"ImapPort: {Settings.ImapPort}");
                    // logowanie 
                    break;
                case 1:
                    Console.WriteLine($"SmtpPort: {Settings.SmtpPort}");
                    // ustawienia
                    break;
                case 2:
                    Console.WriteLine($"ImapHost: {Settings.ImapHost}");
                    break;
                case 3:
                    Console.WriteLine($"Invalid option: {Settings.SmtpHost}");
                    // wyjscie
                    break; 
                case 4:
                    MainMenu.Run();
                break;

                default:
                    break;
            }

        }

    }
}
/*
    *        private int imapPort = 993;
       private int smtpPort = 587;
       private string imapHost = "imap.poczta.onet.pl";
       private string smtpHost = "smtp.poczta.onet.pl";
    */