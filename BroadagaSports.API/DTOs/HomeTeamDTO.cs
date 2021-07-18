using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.DTOs
{
    public class HomeTeamDTO:BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MediumName { get; set; }
 
       
        [JsonProperty("score")]
        public virtual ScoreDTO ScoreDTO { get; set; }

    }
}
