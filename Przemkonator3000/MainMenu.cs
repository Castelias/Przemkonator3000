namespace Przemkonator3000
{
    public static class MainMenu
    {

        public static void Run()
        {
            Menu menu = new Menu("Choose an option:", ["Run", "Settings", "Exit"]);

            int selectedOption = menu.Run();

            switch (selectedOption)
            {
                case 0:
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
                    // wyjscie
                    break;
            }

        }

        // !]S!vx5&khu]vAB
    }
}
