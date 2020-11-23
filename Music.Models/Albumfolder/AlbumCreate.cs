using Music.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class AlbumCreate
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
       //public List<Song> Songs { get; set; } = new List<Song>();
        //public int SongId { get; set; }
        
    }
}
