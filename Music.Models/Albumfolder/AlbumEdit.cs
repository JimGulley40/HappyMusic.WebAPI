﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class AlbumEdit
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
    }
}
