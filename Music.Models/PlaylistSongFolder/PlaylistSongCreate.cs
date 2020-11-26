using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class PlaylistSongCreate
    {
        public int PlaylistSongId { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
      
    }
}
