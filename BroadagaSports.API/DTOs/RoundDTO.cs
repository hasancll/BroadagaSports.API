using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.DTOs
{
    public class RoundDTO:BaseDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
