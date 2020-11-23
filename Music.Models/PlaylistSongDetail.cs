using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class PlaylistSongDetail
    {
        public int PlaylistSongId { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
