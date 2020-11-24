using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models.AlbumArtistFolder
{
    public class AlbumArtistListItem
    { 
        [Key]
        public int AlbumArtistId { get; set; }
        //public int ArtistId { get; set; }
        //public int AlbumId { get; set; }
        public List<AlbumDetail> Albums { get; set; } = new List<AlbumDetail>();
        public List<ArtistDetail> Artist { get; set; } = new List<ArtistDetail>();
    }
}
