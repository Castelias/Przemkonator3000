namespace Przemkonator3000
{
    /// <summary>
    /// This class is used to create a menu that user can move thru with UP and DOWN arrows, pressing Enter selects current option.
    /// To use this class u have create a instance of this class with parameters (string prompt, string[] options) then u create a intiger with assigned value of created instance [ int x = instance.Run() ]
    /// then u create a switch(x) statement that depents on created int.Inside this switch in every case u put your desired function.
    /// </summary>
    public class Menu
    {
        private int _selectedIndex;
        private string[] _options;
        private string _prompt;

        public Menu(string prompt, string[] options)
        {
            _prompt = prompt;
            _options = options;
            _selectedIndex = 0;
        }

        private void DisplayOptions()
        {
            Console.WriteLine(_prompt);
            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                string prefix;
                if (i == _selectedIndex)
                {
                    prefix = "||";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix}<[ {currentOption} ]>{prefix}");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return _selectedIndex;
        }
    }
}
