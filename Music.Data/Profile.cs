using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
