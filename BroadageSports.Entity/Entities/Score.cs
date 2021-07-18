using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Entity.Entities
{
    public class Score:BaseEntity
    {
        public int Regular { get; set; }
        public int HalfTime { get; set; }
        public int Current { get; set; }
        public int Penalties { get; set; }
        public int ExtraTime { get; set; }

        public virtual AwayTeam AwayTeam { get; set; }
        public virtual HomeTeam HomeTeam { get; set; }

    }
}
