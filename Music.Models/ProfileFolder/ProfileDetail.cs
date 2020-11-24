using Music.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models.ProfileFolder
{
    public class ProfileDetail
    {
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
