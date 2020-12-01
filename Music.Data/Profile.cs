using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public enum ContactPreference { SMS=1,Phone,Email,Mail}
        
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Song> Songs { get; set; } = new List<Song>();
        public int MembershipLevel { get; set; }
        public DateTime RenewalDate { get; set; }
        
        public string Email { get; set; }
        public ContactPreference ContactPreference { get; set; }
        //public List<Artist> FavoriteArtist { get; set; }
        public virtual List<FavoriteArtist> FavoriteArtist { get; set; }

    }
}
