using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Menus;

namespace MyPlaylists.MainMenuOptions
{
    internal class SignIn
    {
        public void LogIn()
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                Console.Clear();

                string user = "Username:";

                CenterTextMethod.CenterText(user, 5, 1);
                Console.WriteLine(user);
                CenterTextMethod.CenterText(user, 5, 2);
                Console.WriteLine("".PadRight(user.Length, '_'));

                CenterTextMethod.CenterText(user, 5, 4);
                Console.WriteLine("Парола:");
                CenterTextMethod.CenterText(user, 5, 5);
                Console.WriteLine("".PadRight(user.Length, '_'));

                CenterTextMethod.CenterText(user, 5, 2);
                string username = UsernameInput((Console.WindowWidth - user.Length) / 2, 15, "_");


                CenterTextMethod.CenterText(user, 5, 5);
                string password = PasswordCover((Console.WindowWidth - user.Length) / 2, 18, "_");

                var a = db.Users.Where(user => user.Username == username && user.Password == password).ToArray();

                if (a.Length >= 1)
                {
                    AccountMenu b = new AccountMenu();
                    b.Menu(a[0].UserId);
                }
                else
                {
                    throw new Exception("Incorrect username or password");
                }
            }
        }
        public string UsernameInput(int left, int top, string deleteIndex)
        {
            string username = null;
            while (true)
            {
                var key = Console.ReadKey();
                int count = 0;
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && username.Length > 0)
                {
                    username = username.Remove(username.Length - 1, 1);
                    left--;
                    Console.SetCursorPosition(left, top);
                    Console.Write(deleteIndex);
                }
                else if (key.Key == ConsoleKey.Backspace && username.Length == 0)
                {
                    Console.SetCursorPosition(left, top);
                    continue;
                }
                else
                {
                    username += key.KeyChar;
                    if (count == 0)
                    {
                        Console.SetCursorPosition(left + 1, top);
                        count++;

                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);

                    }
                    left++;
                }
            }
            return username;
        }
        public string PasswordCover(int left, int top, string deleteIndex)
        {
            string password = null;

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1, 1);
                    left--;
                    Console.SetCursorPosition(left, top);
                    Console.Write(deleteIndex);
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length == 0)
                {
                    Console.SetCursorPosition(left, top);
                    continue;
                }
                else
                {
                    password += key.KeyChar;
                    Console.SetCursorPosition(left, top);
                    Console.Write('*');
                    left++;
                }
            }
            return password;
        }
    }
}
