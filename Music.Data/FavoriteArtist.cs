using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class FavoriteArtist
    { 
        public int FavoriteArtistId { get; set; }
        public int ArtistId { get; set; }
        public int ProfileId { get; set; }
        public string ArtistName { get; set; }
       
    }
}
