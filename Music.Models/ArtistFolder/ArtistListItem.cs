using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class ArtistListItem
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
