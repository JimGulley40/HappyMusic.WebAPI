using Music.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class PlaylistListItem
    {
        public int PlaylistId { get; set; }
        public string Playlistname { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int NumberOfSongs { get; set; }
        public List<PlaylistSongListItem> PlaylistSongs { get; set; } 
        //public List<Song> Song { get; set; } = new List<Song>();

    }
}
