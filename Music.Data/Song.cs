using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //[Required]
        public int? AlbumID { get; set; }
        [Required]
        public string Lyrics { get; set; }
        //[Required]
        public int? SongCount { get; set; }
        [Required]
        public bool IsExplicit { get; set; }
        //[Required]
        public TimeSpan? SongLength { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
