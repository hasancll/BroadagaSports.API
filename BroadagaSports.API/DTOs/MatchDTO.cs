using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.DTOs
{
    public class MatchDTO:BaseDTO
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("homeTeam")]
        public virtual HomeTeamDTO HomeTeamDTO { get; set; }
        [JsonProperty("awayTeam")]
        public virtual AwayTeamDTO AwayTeamDTO { get; set; }
        [JsonProperty("status")]
        public virtual StatusDTO StatusDTO { get; set; }
        [JsonProperty("tournament")]
        public virtual TournamentDTO TournamentDTO { get; set; }
        [JsonProperty("round")]
        public virtual RoundDTO RoundDTO { get; set; }
        [JsonProperty("stage")]
        public virtual StageDTO StageDTO { get; set; }
        public int CurrentMinute { get; set; }
        public int Stoppage { get; set; }
    }
}
