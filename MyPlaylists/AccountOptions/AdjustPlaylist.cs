using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Menus;
using MyPlaylists.AdjustOptions;
using Microsoft.EntityFrameworkCore;

namespace MyPlaylists.AccountOptions
{
    internal class AdjustPlaylist
    {
        //public AdjustPlaylist(DbContext )
        //{

        //}
        public void AdjustMenu(int playlistId)
        {
            Console.Clear();
            PrintAdjust();

            ConsoleKeyInfo button = default;
            ConsoleKeyInfo pressedKey;

            do
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;

                pressedKey = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.D4)
                {
                    button = pressedKey;
                    PrintAdjust(button.KeyChar - 48);
                }
                else if (pressedKey.Key != ConsoleKey.Enter)
                {
                    PrintAdjust();
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
                AddSongToPlaylist add = new AddSongToPlaylist();
                add.AddSong(playlistId);
            }
            else if (button.Key == ConsoleKey.D2)
            {
                RemoveSongFromPlaylist remove = new RemoveSongFromPlaylist();
                remove.RemoveSong(playlistId);
            }
            else if (button.Key == ConsoleKey.D3)
            {
                PrintSongs printSongs = new PrintSongs();
                printSongs.Print(playlistId);
            }
            else if (button.Key == ConsoleKey.D4)
            {
                FilterGenre filterGenre = new FilterGenre();
                filterGenre.Genre(playlistId);
            }
        }
        public void Playlist(int accId)
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                Console.Clear();
                string question = "Which playlist do you want to Adjust?";
                CenterTextMethod.CenterText(question, 4, 1);
                Console.WriteLine(question);

                string name = Console.ReadLine();
                var a = db.Playlists.Where(playlist => playlist.Name == name && playlist.UserId == accId).ToArray();
                if(a.Length == 0)
                {
                    Console.WriteLine("Incorect playlist name or it doesnt exist.");
                    //AccountMenu menu = new AccountMenu();
                    //menu.Menu(accId);
                    Playlist(accId);
                }
                else
                {
                    AdjustMenu(a[0].PlaylistId);
                }
            }
        }
        
        private static void PrintAdjust(int button = -1)
        {
            string optionOne = "1) Add song";
            string optionTwo = "2) Remove song";
            string optionThree = "3) Print songs";
            string optionFour = "4) Filter genre";

            var defaultColor = ConsoleColor.Gray;
            var selectedColor = ConsoleColor.Cyan;

            Console.ForegroundColor = button == 1 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 6, 1);
            Console.WriteLine(optionOne);

            Console.ForegroundColor = button == 2 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 6, 2);
            Console.WriteLine(optionTwo);

            Console.ForegroundColor = button == 3 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 6, 3);
            Console.WriteLine(optionThree);

            Console.ForegroundColor = button == 4 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 6, 4);
            Console.WriteLine(optionFour);

            Console.ForegroundColor = defaultColor;
        }
    }
}
