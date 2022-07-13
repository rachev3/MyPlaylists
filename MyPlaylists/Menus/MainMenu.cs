using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.MainMenuOptions;

namespace MyPlaylists.Menus
{
    internal class MainMenu
    {
        public void Menu()
        {
            Console.Clear();
            PrintMainMenu();

            ConsoleKeyInfo button = default;
            ConsoleKeyInfo pressedKey;

            do
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;

                pressedKey = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.D2)
                {
                    button = pressedKey;
                    PrintMainMenu(button.KeyChar - 48);
                }
                else if (pressedKey.Key != ConsoleKey.Enter)
                {
                    PrintMainMenu();
                    button = default;
                }
            }
            while (pressedKey.Key != ConsoleKey.Enter);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = true;

            if (button == default)
            {
                throw new Exception("There is no option selected");
            }
            else if (button.Key == ConsoleKey.D1)
            {
                try
                {
                    CreateAccount a = new CreateAccount();
                    a.CreateAcc();
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    var message = ex.Message;
                    CenterTextMethod.CenterText(message, 1, 1);
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else if (button.Key == ConsoleKey.D2)
            {
                SignIn a = new SignIn();
                a.LogIn();
            }
        }
        private void PrintMainMenu(int button = -1)
        {
            string optionOne = "1) Create an account";
            string optionTwo = "2) Sign in";

            var defaultColor = ConsoleColor.Gray;
            var selectedColor = ConsoleColor.Cyan;

            Console.ForegroundColor = button == 1 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 4, 1);
            Console.WriteLine(optionOne);

            Console.ForegroundColor = button == 2 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 4, 2);
            Console.WriteLine(optionTwo);

            Console.ForegroundColor = defaultColor;
        }

    }
}
