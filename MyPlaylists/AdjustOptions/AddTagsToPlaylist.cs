using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlaylists.Models;
using MyPlaylists.AccountOptions;

namespace MyPlaylists.AdjustOptions
{
    public class AddTagsToPlaylist
    {
        public void AddTag(int playlistId)
        {
            Console.Clear();
            string head = "Add-Tag:";
            CenterTextMethod.CenterText(head, 4, 1);
            Console.WriteLine(head);
            CenterTextMethod.CenterText(head, 4, 2);
            string name = Console.ReadLine();

            Tag tag = new Tag();
            tag.TagName = name;

            using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
            {
                TagPlaylist tagPlaylist = new TagPlaylist();
                tagPlaylist.PlaylistId= playlistId;
                
                var tagCheck = db.Tags.Where(tag => tag.TagName == name).ToList();
                if (tagCheck.Count == 0)
                {

                    tagPlaylist.Tag = tag;
                }
                else
                {
                    tagPlaylist.TagId = tagCheck[0].TagId;
                }
                db.TagsPlaylists.Add(tagPlaylist);
                db.SaveChanges();
            }

            AdjustPlaylist ap = new AdjustPlaylist();
            ap.AdjustMenu(playlistId);
        }
    }
}
