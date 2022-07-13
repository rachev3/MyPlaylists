using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylists.Models
{
    public class Tag
    {
        public Tag()
        {
            this.TagsPlaylists = new List<TagPlaylist>();
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public ICollection<TagPlaylist> TagsPlaylists { get; set; }
    }
}
