using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongDetail
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Lyrics { get; set; }
        public bool IsExplicit { get; set; }
        public int AlbumID { get; set;  }
        public string AlbumName { get; set; }
    }
}
