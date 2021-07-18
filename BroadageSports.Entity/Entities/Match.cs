using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Entity.Entities
{
    public class Match : BaseEntity
    {
        public int MatchGlobalId { get; set; }

        public DateTime Date { get; set; }
        public virtual HomeTeam HomeTeam { get; set; }
        public virtual AwayTeam AwayTeam { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        [ForeignKey("Stage")]
        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }
        [ForeignKey("Round")]
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }
        public int CurrentMinute { get; set; }
        public int Stoppage { get; set; }
    }
}
