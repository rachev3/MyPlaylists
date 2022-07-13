using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists.Models
{
    public class Song
    {
        public Song()
        {
            this.PlaylistsSongs = new List<PlaylistSong>();
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public ICollection<PlaylistSong> PlaylistsSongs { get; set; }
    }
}
