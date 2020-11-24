using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongListItem
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        
        public string AlbumName { get; set; }
       
        public string PlaylistName { get; set; }

    }
}
