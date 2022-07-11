using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyPlaylists.Models
{
    
    public class PlaylistSong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
