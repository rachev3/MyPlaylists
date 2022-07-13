using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Models;
using MyPlaylists.AccountOptions;

namespace MyPlaylists.AdjustOptions
{
    public class PrintSongs
    {
        public void Print(int playlistId)
        {
            Console.Clear();
           
            using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var pl = db.PlaylistsSongs.Where(playlist => playlist.PlaylistId == playlistId).ToList();
                var playlist = db.Playlists.Where(playlist=> playlist.PlaylistId == playlistId).ToList();
                Console.WriteLine(playlist[0].Name);
                PrintTags(playlistId);
                Console.WriteLine("------");
                foreach(var song in pl)
                {
                    var song1 = db.Songs.Where(song1=>song1.SongId == song.SongId).ToList();
                    Console.WriteLine(song1[0].SongName);
                }
                Console.WriteLine();

                Menu(playlistId);
            }
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
        private void Menu(int playlistId)
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
                AdjustPlaylist adjust = new AdjustPlaylist();
                adjust.AdjustMenu(playlistId);
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

    }
}
