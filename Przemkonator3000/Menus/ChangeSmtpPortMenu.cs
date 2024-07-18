namespace Przemkonator3000.Menus
{
    public static class ChangeSmtpPortMenu
    {

        public static void Run()
        {
            Console.WriteLine("Change Smtp Port: ");
            Console.WriteLine("If you leave it empty a change won't happen.");
            var newSmtpPort = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newSmtpPort))
            {
                Settings.Instance.SmtpPort = Convert.ToInt16(newSmtpPort);
                Console.WriteLine("Smtp Host has been changed.");
                Settings.Instance.SaveSettings();
                Settings.Instance.LoadSettings();

            }
            else
            {
                Console.WriteLine("No changes made to SMTP Port.");
            }
        }

    }
}
