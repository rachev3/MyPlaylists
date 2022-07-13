using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists.Models
{
    public class Playlist
    {
        public Playlist()
        {
            this.PlaylistsSongs = new List<PlaylistSong>();
            this.TagPlaylists = new List<TagPlaylist>();
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaylistId { get; set; }        
        public string Name { get; set; }

        public ICollection<PlaylistSong> PlaylistsSongs { get; set; }
        public ICollection<TagPlaylist> TagPlaylists { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
