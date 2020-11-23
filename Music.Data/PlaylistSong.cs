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
       
        //[ForeignKey(nameof(Playlist))]
        public int PlaylistId { get; set; }
        //public virtual Playlist Playlist { get; set; }
       
        [ForeignKey(nameof(Songs))]
        public int SongId { get; set; }
        public virtual Song Songs { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid PlaylistOwnerId { get; set; }

    }
}

