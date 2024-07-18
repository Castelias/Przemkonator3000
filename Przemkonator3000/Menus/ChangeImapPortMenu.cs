
namespace Przemkonator3000.Menus
{
    public static class ChangeImapPortMenu
    {

        public static void Run()
        {
            Console.WriteLine("Change Imap Port: ");
            Console.WriteLine("If you leave it empty a change won't happen.");
            var newImapPort = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newImapPort))
            {
                Settings.Instance.ImapPort = Convert.ToInt16(newImapPort);
                Console.WriteLine("Smtp Host has been changed.");
                Settings.Instance.SaveSettings();
                Settings.Instance.LoadSettings();

            }
            else
            {
                Console.WriteLine("No changes made to Imap Port.");
            }
        }


    }
}
