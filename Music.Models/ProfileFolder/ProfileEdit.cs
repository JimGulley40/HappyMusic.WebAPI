using Music.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models.ProfileFolder
{
    public class ProfileEdit
    {
        
        public string UserName { get; set; }
        public int ProfileId { get; set; }
        public int MembershipLevel { get; set; }
        public DateTime RenewalDate { get; set; }
        public string Email { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public List<Artist> FavoriteArtist { get; set; }
    }
}
