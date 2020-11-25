using Music.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models.ProfileFolder
{
    public class ProfileListItems
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public List<SongDetail> Songs { get; set; } = new List<SongDetail>();

    }
}
