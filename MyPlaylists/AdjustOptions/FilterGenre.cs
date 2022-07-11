using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists.AdjustOptions
{
    public class FilterGenre
    {
        public void Filter(int playlistId, string genre)
        {
            Console.Clear();
            using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var pl = db.PlaylistsSongs.Where(playlist => playlist.PlaylistId == playlistId).ToList();
                var playlist = db.Playlists.Where(playlist => playlist.PlaylistId == playlistId).ToList();
                Console.WriteLine($"{playlist[0].Name} : {genre}");
                Console.WriteLine("------");

                foreach(var song in pl)
                {
                    var song1 = db.Songs.Where(song1 => song1.SongId == song.SongId).ToList();
                    if (song1[0].Genre == genre)
                    {
                        Console.WriteLine(song1[0].SongName);
                    }
                }
            }
        }
        public void Genre(int playlistId)
        {
            Console.Clear();
            string question = "Genre filter:";
            CenterTextMethod.CenterText(question,2,1);
            Console.WriteLine(question);
            CenterTextMethod.CenterText(question, 2, 2);
            string genre = Console.ReadLine();
            Filter(playlistId, genre);
        }
    }
}
