using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Menus;
using MyPlaylists.Models;


namespace MyPlaylists.MainMenuOptions
{
    internal class CreateAccount
    {
        public void CreateAcc()
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                Console.Clear();
                User user = new User();

                Console.WriteLine("Username:");
                user.Username = Console.ReadLine();

                Console.WriteLine("Password:");
                user.Password = PasswordCover(0, 3, " ");

                Console.WriteLine("Name:");
                user.Name = Console.ReadLine();

                db.Users.Add(user);
                db.SaveChanges();

                MainMenu a = new MainMenu();
                a.Menu();
            }
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
