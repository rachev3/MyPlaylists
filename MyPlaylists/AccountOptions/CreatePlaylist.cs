using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Menus;
using MyPlaylists.Models;

namespace MyPlaylists.AccountOptions
{
    internal class CreatePlaylist
    {
        public void Creation(int accId)
        {
            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                Console.Clear();
                string chooseName = "Name of the Playlist:";
                CenterTextMethod.CenterText(chooseName, 4, 1);
                Console.WriteLine(chooseName);


                Playlist playlist = new Playlist();
                CenterTextMethod.CenterText(chooseName, 4, 2);
                playlist.Name = Console.ReadLine();

                var a = db.Users.Where(user => user.UserId == accId).ToArray();
                a[0].Playlists.Add(playlist);
                db.SaveChanges();
            }
            AccountMenu menu = new AccountMenu();
            menu.Menu(accId);
        }
    }
}
