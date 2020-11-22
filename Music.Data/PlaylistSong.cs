using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
   public class PlaylistSong
    {
        [Key]
        public int PlaylistSongId { get; set; }
        [Required]
        public int PlaylistId { get; set; }
       
        public virtual List<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid PlaylistOwnerId { get; set; }

    }
}
