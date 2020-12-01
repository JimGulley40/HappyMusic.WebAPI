﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class ArtistEdit
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public bool IsFavoriteArtist { get; set; }

    }
}
