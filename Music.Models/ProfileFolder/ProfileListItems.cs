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
        public int MembershipLevel { get; set; }
        public DateTime RenewalDate { get; set; }
        public string Email { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public List<ArtistDetail> Artists { get; set; }/* = new List<FavoriteArtist>();*/
       //public string FavoriteArtist { get; set; }

    }
}
