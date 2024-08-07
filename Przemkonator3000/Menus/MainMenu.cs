namespace Przemkonator3000.Menus
{
    public static class MainMenu
    {
        public static void Run()
        {
            Menu menu = new("Choose an option:", ["Run", "Settings", "Exit"]);

            int selectedOption = menu.Run();

            switch (selectedOption)
            {
                case 0:
                    Settings.Instance.LoadSettings();
                    RunAppMenu.Run();
                    break;
                case 1:
                    SettingsMenu.Run();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
