
namespace Przemkonator3000.Menus
{
    public static class ChangeSmtpHostMenu
    {
        public static void Run()
        {

            Console.WriteLine("Change Smtp Host: ");
            Console.WriteLine("If you leave it empty a change won't happen.");
            var newSmtpHost = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newSmtpHost))
            {
                Settings.Instance.SmtpHost = newSmtpHost;
                Console.WriteLine("Smtp Host has been changed.");
                Settings.Instance.SaveSettings();
                Settings.Instance.LoadSettings();

            }
            else
            {
                Console.WriteLine("No changes made to SMTP Host.");
            }

        }

    }
}
