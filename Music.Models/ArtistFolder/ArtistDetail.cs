using Music.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class ArtistDetail
    {
        [Key]
        public int ArtistId { get; set; }
        public Guid OwnerId { get; set; }
        public string ArtistName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public object ModifiedUtc { get; set; }
        public bool IsFavoriteArtist { get; set; }

    }
}
