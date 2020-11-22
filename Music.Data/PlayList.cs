using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public string PlaylistName { get; set; }
        [Required]
        public int ProfileID { get; set; }
        
        public int NumberOfSongs
        {
            get
            {
                int songcounter = 0;
                foreach (Song song in Songs)
                {
                    songcounter++;
                }
                return songcounter;
            }
        }
        [Required]
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual List<Song> Songs { get; set; } = new List<Song>();
        public int PlaylistSongId { get; set; }
        [ForeignKey(nameof(PlaylistSong))]
        public virtual PlaylistSong PlaylistSong { get; set; }
    }
}
