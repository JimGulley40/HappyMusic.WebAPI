using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models.AlbumArtistFolder
{
    public  class AlbumArtistCreate
    {
        [Key]
        public int AlbumArtistId {get; set;}
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
