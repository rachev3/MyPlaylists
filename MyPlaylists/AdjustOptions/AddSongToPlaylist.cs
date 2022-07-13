using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Models;
using MyPlaylists.AccountOptions;

namespace MyPlaylists.AdjustOptions
{
    internal class AddSongToPlaylist
    {
        public void AddSong(int playlistId)
        {
            Console.Clear();

            string head = "Add-Song";

            CenterTextMethod.CenterText(head, 13, 1);
            Console.WriteLine(head);

            CenterTextMethod.CenterText(head, 13, 2);
            Console.WriteLine("".PadRight(head.Length, '_'));

            CenterTextMethod.CenterText(head, 13, 3);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 13, 4);
            Console.WriteLine("Name:");

            CenterTextMethod.CenterText(head, 13, 5);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 13, 6);
            Console.WriteLine("Artist:");

            CenterTextMethod.CenterText(head, 13, 7);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 13, 8);
            Console.WriteLine("Genre:");

            CenterTextMethod.CenterText(head, 13, 9);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 13, 10);
            Console.WriteLine("Url:");

            CenterTextMethod.CenterText(head, 13, 11);
            Console.WriteLine();

            CenterTextMethod.CenterText(head, 13, 5);
            string name = Console.ReadLine();

            CenterTextMethod.CenterText(head, 13, 7);
            string artist = Console.ReadLine();

            CenterTextMethod.CenterText(head, 13, 9);
            string genre = Console.ReadLine();

            CenterTextMethod.CenterText(head, 13, 11);
            string url = Console.ReadLine();

            Song song = new Song();
            song.SongName = name;
            song.Artist = artist;
            song.Genre = genre;
            song.Url = url;

             

            using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                PlaylistSong playlistSong = new PlaylistSong();
                playlistSong.PlaylistId = playlistId;
               
                var songCheck = db.Songs.Where(song => song.SongName == name && song.Artist == artist && song.Genre == genre && song.Url == url).ToList();
                if (songCheck.Count == 0)
                {
                    playlistSong.Song = song;
                }
                else
                {                   
                    playlistSong.SongId = songCheck[0].SongId;
                }
                db.PlaylistsSongs.Add(playlistSong);
                db.SaveChanges();
            }
            AdjustPlaylist adjust = new AdjustPlaylist();
            adjust.AdjustMenu(playlistId);
        }
        
    }
}
