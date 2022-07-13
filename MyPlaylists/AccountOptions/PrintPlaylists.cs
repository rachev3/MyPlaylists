using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Menus;
using MyPlaylists.Models;

namespace MyPlaylists.AccountOptions
{
    public class PrintPlaylists
    {
        public void Print(int accId)
        {
            Console.Clear();
            using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                
                List<Playlist> playlists = db.Playlists.Where(playlist=>playlist.UserId==accId).ToList();
                foreach(Playlist playlist in playlists)
                {
                    Console.WriteLine(playlist.Name);
                    PrintTags(playlist.PlaylistId);
                    Console.WriteLine("-----");
                    PrintSongs(playlist.PlaylistId);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Menu(accId);
        }
        private void PrintTags(int playlistId)
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var tags = db.TagsPlaylists.Where(tg => tg.PlaylistId == playlistId).ToList();
                Console.Write("(");
                int counter = 0;
                foreach (var tag in tags)
                {
                    if (counter != 0)
                    {
                        Console.Write(",");
                    }

                    var t = db.Tags.Where(p => p.TagId == tag.TagId).ToList();
                    Console.Write(t[0].TagName);
                    counter++;
                }
                Console.Write(")");
                Console.WriteLine();
            }
        }
        private void PrintSongs(int playlistId)
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var songs = db.PlaylistsSongs.Where(pl => pl.PlaylistId == playlistId).ToList();
                foreach (var song in songs)
                {
                    var i = db.Songs.Where(p => p.SongId == song.SongId).ToList();
                    Console.WriteLine(i[0].SongName);
                }
            }
        }
        private void PrintMenu(int button = -1)
        {
            string optionOne = "1) <--- Back";

            var defaultColor = ConsoleColor.Gray;
            var selectedColor = ConsoleColor.Cyan;

            Console.ForegroundColor = button == 1 ? selectedColor : defaultColor;
            CenterTextMethod.CenterText(optionOne, 4, 1);
            Console.WriteLine(optionOne);

            Console.ForegroundColor = defaultColor;
        }
        private void Menu(int accId)
        {
            PrintMenu();
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
                    PrintMenu(button.KeyChar - 48);
                }
                else if (pressedKey.Key != ConsoleKey.Enter)
                {
                    PrintMenu();
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
                AccountMenu menu = new AccountMenu();
                menu.Menu(accId);
            }

        }
    }
}
