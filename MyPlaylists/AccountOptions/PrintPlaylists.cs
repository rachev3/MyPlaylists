using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists.AccountOptions
{
    public class PrintPlaylists
    {
        public void Print(int userId)
        {
            Console.Clear();
            using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var playlists = db.Playlists.Where(playlist=>playlist.UserId == userId).ToList();
                var user = db.Users.Where(user=> user.UserId == userId).ToList();
                Console.WriteLine(user[0].Name);
                Console.WriteLine("-----");
                foreach(var playlist in playlists)
                {
                    Console.WriteLine(playlist.Name);
                }
            }
        } 
    }
}
