using Music.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class AlbumListItem
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public List<SongDetail> Songs { get; set; } = new List<SongDetail>();
        public string ArtistName { get; set; }
        public List<AlbumArtist> AlbumArtist { get; set; }
        public List<ArtistDetail> Artists { get; set; } = new List<ArtistDetail>();
        //public int SongId { get; set; }
        //public string SongTitle { get; set; }
    }
}
