using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.AccountOptions;
using MyPlaylists.Models;

namespace MyPlaylists.AdjustOptions
{
    public class RemoveTagFromPlaylist
    {
        public void RemoveTag(int playlistId)
        {
            Console.Clear();
            string head = "Remove-Tag:";
            CenterTextMethod.CenterText(head, 4, 1);
            Console.WriteLine(head);
            CenterTextMethod.CenterText(head, 4, 2);
            string name = Console.ReadLine();

            Tag tag = new Tag();
            tag.TagName = name;

            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                var tag1 = db.Tags.Where(p => p.TagName == name).ToList();
                var tagPlaylist = db.TagsPlaylists.Where(p => p.PlaylistId == playlistId && p.TagId == tag1[0].TagId ).ToList();
                db.TagsPlaylists.Remove(tagPlaylist[0]);
                db.SaveChanges();
            }

            AdjustPlaylist ap = new AdjustPlaylist();
            ap.AdjustMenu(playlistId);
        }
    }
}
