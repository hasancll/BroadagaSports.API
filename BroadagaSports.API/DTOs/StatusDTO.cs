using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.DTOs
{
    public class StatusDTO:BaseDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        //public virtual MatchDTO MatchDTO { get; set; }
    }
}
