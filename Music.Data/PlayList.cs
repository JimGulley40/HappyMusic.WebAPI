using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class PlayList
    {
        [Key]
        public int PlaylistId { get; set;}
        [Required]
        public string PlaylistName { get; set;}
        public int SongId { get; set; }
        public int ProfileID { get; set; }
    }
}
