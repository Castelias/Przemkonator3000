
namespace Przemkonator3000.Menus
{
    public static class ChangeImapHostMenu
    {
        public static void Run()
        {

            Console.WriteLine("Change Imap Host: ");
            Console.WriteLine("If you leave it empty a change won't happen.");
            var newImapHost = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newImapHost))
            {
                Settings.Instance.ImapHost = newImapHost;
                Console.WriteLine("Smtp Host has been changed.");
                Settings.Instance.SaveSettings();
                Settings.Instance.LoadSettings();
            }
            else
            {
                Console.WriteLine("No changes made to Imap Host.");
            }

        }
    }
    
}
