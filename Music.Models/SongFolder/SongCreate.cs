﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongCreate
    {
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public bool IsExplicit { get; set; }
    }
}