using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{

    public enum Genre { Rock = 1, Jazz, EasyListening, Punk, Folk, Pop, Christian, Country, Classical, HipHop, Latin, Holiday, Focus, Electronic, Indie, Decades, Alternative, Soul, K_Pop, Blues, Afro, Metal, Kids }
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public object ModifiedUtc { get; set; }
    }

}
