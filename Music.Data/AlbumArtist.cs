using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class AlbumArtist
    {
        [Key]
        public int AlbumArtistId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public virtual Artist Artist { get; set; }
    }
}
