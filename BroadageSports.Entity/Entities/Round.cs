﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Entity.Entities
{
    public class Round : BaseEntity 
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        //public virtual IEnumerable<Match> Match { get; set; }
        public virtual Match Match { get; set; }
    }
}
