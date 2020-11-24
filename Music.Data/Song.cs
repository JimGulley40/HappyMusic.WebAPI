using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public string Title { get; set; }
       
        [ForeignKey(nameof(Album))]
        public int AlbumID { get; set; }

        public virtual Album Album { get; set; }
        [Required]
        public string Lyrics { get; set; }
      
        // public int? SongCount { get; set; }
        [Required]

        public bool IsExplicit { get; set; }
        public string PlaylistName { get; set; }
        
       // public TimeSpan? SongLength { get; set; }
       
        //[ForeignKey(nameof(Playlist))]
        //public int PlaylistId { get; set; }

        //public virtual Playlist Playlist { get; set; }
        //public DateTimeOffset CreatedUtc { get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
