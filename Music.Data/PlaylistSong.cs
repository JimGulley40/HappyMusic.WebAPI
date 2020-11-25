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
        //[ForeignKey(nameof(PlaylistId))]
        //public virtual Playlist Playlist { get; set; }
        [Required]
        public int SongId { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public Guid PlaylistOwnerId { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public string Lyrics { get; set; }
        public string AlbumName { get; set; }


    }
}

