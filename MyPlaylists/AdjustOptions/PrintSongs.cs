using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Models;

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
                Console.WriteLine("------");
                foreach(var song in pl)
                {
                    var song1 = db.Songs.Where(song1=>song1.SongId == song.SongId).ToList();
                    Console.WriteLine(song1[0].SongName);
                }

            }
        }
            
    }
}
