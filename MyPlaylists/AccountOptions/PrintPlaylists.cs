using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
