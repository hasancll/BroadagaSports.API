using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.DTOs
{
    public class ScoreDTO
    {
        public int Regular { get; set; }
        public int HalfTime { get; set; }
        public int Current { get; set; }
        public int Penalties { get; set; }
        public int ExtraTime { get; set; }

    }
}
