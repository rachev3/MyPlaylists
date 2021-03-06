using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Models;
using MyPlaylists.AccountOptions;

namespace MyPlaylists.AdjustOptions
{
    internal class RemoveSongFromPlaylist
    {
        public void RemoveSong(int playlistId)
        {
            Console.Clear();

            string head = "Remove-Song";

            CenterTextMethod.CenterText(head, 9, 1);
            Console.WriteLine(head);

            CenterTextMethod.CenterText(head, 9, 2);
            Console.WriteLine("".PadRight(head.Length, '_'));

            CenterTextMethod.CenterText(head, 9, 3);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 9, 4);
            Console.WriteLine("Name:");

            CenterTextMethod.CenterText(head, 9, 5);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 9, 6);
            Console.WriteLine("Artist:");

            CenterTextMethod.CenterText(head, 9, 7);
            Console.WriteLine();       

            CenterTextMethod.CenterText(head, 9, 5);
            string name = Console.ReadLine();

            CenterTextMethod.CenterText(head, 9, 7);
            string artist = Console.ReadLine();
            
            

            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var song = db.Songs.Where(song => song.SongName == name && song.Artist == artist).ToList();
                int songId = song[0].SongId;
                
                var playlistSong = db.PlaylistsSongs.Where(pl => pl.SongId == songId && pl.PlaylistId == playlistId).ToList();

                db.PlaylistsSongs.Remove(playlistSong[0]);
                db.SaveChanges();
            }
            AdjustPlaylist adjustPlaylist = new AdjustPlaylist();
            adjustPlaylist.AdjustMenu(playlistId);
        }
    }
}
