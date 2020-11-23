using Music.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class PlaylistDetail
    {
        public int PlaylistId { get; set; }
        public string Playlistname { get; set; }
        public int SongId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int NumberOfSongs { get; set; }

        public List<PlaylistSong> Songs { get; set; } = new List<PlaylistSong>();


    }
}
