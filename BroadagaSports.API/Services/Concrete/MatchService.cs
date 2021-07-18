using BroadagaSports.API.DTOs;
using BroadagaSports.API.Services.Abstract;
using BroadagaSports.API.UnitOfWork.Abstract;
using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Entity.Includable;
using BroadageSports.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BroadagaSports.API.Logging.Abstract;

namespace BroadagaSports.API.Services.Concrete
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMatchRepository _matchRepository;
        public MatchService(IUnitOfWork unitOfWork)
        {
            _matchRepository = unitOfWork.Match;
            _unitOfWork = unitOfWork;
        }
        public async Task<MatchDTO> AddMatchAsync(MatchDTO matchDTO)
        {
            var matches = new Match
            {
                HomeTeam = new HomeTeam
                {
                    Id = matchDTO.HomeTeamDTO.Id,
                    MediumName = matchDTO.HomeTeamDTO.MediumName,
                    Name = matchDTO.HomeTeamDTO.Name,
                    ShortName = matchDTO.HomeTeamDTO.ShortName,

                },
                AwayTeam = new AwayTeam
                {
                    Name = matchDTO.AwayTeamDTO.Name,
                    MediumName = matchDTO.AwayTeamDTO.MediumName,
                    ShortName = matchDTO.AwayTeamDTO.ShortName
                },
                CurrentMinute = matchDTO.CurrentMinute,
                Date = matchDTO.Date,
                Stage = new Stage
                {
                    Name = matchDTO.StageDTO.Name,
                    ShortName = matchDTO.StageDTO.ShortName,
                },
                Tournament = new Tournament
                {
                    Name = matchDTO.TournamentDTO.Name,
                    ShortName = matchDTO.TournamentDTO.ShortName,
                },
                Stoppage = matchDTO.Stoppage,
                Round = new Round
                {
                    Name = matchDTO.RoundDTO.Name,
                    ShortName = matchDTO.RoundDTO.ShortName
                },
                Status = new Status
                {
                    Name = matchDTO.StatusDTO.Name,
                    ShortName = matchDTO.StatusDTO.ShortName
                }

            };
            await _matchRepository.AddAsync(matches).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return matchDTO;
        }

        public async Task<List<MatchDTO>> AddRangeMatchAsync(List<MatchDTO> matchDTOs)
        {
            try
            {
                var matches = from mc in matchDTOs
                              select new Match
                              {
                                  MatchGlobalId = mc.Id,
                                  HomeTeam = new HomeTeam
                                  {
                                      MediumName = mc.HomeTeamDTO.MediumName,
                                      Name = mc.HomeTeamDTO.Name,
                                      ShortName = mc.HomeTeamDTO.ShortName,
                                      Score = new Score
                                      {
                                          Current = mc.HomeTeamDTO.ScoreDTO.Current,
                                          Penalties = mc.HomeTeamDTO.ScoreDTO.Penalties,
                                          ExtraTime = mc.HomeTeamDTO.ScoreDTO.ExtraTime,
                                          HalfTime = mc.HomeTeamDTO.ScoreDTO.HalfTime,
                                          Regular = mc.HomeTeamDTO.ScoreDTO.Regular,

                                      }

                                  },
                                  AwayTeam = new AwayTeam
                                  {
                                      Name = mc.AwayTeamDTO.Name,
                                      MediumName = mc.AwayTeamDTO.MediumName,
                                      ShortName = mc.AwayTeamDTO.ShortName,
                                      Score = new Score
                                      {
                                          Current = mc.AwayTeamDTO.ScoreDTO.Current,

                                          Penalties = mc.HomeTeamDTO.ScoreDTO.Penalties,
                                          ExtraTime = mc.HomeTeamDTO.ScoreDTO.ExtraTime,
                                          HalfTime = mc.HomeTeamDTO.ScoreDTO.HalfTime,
                                          Regular = mc.HomeTeamDTO.ScoreDTO.Regular,
                                      }

                                  },
                                  CurrentMinute = mc.CurrentMinute,
                                  Date = mc.Date,
                                  Stage = new Stage
                                  {
                                      Name = mc.StageDTO.Name,
                                      ShortName = mc.StageDTO.ShortName,
                                  },
                                  Tournament = new Tournament
                                  {
                                      Name = mc.TournamentDTO.Name,
                                      ShortName = mc.TournamentDTO.ShortName,
                                  },
                                  Stoppage = mc.Stoppage,
                                  Round = new Round
                                  {
                                      Name = mc.RoundDTO.Name,
                                      ShortName = mc.RoundDTO.ShortName
                                  },
                                  Status = new Status
                                  {
                                      Name = mc.StatusDTO.Name,
                                      ShortName = mc.StatusDTO.ShortName
                                  },


                              };
                await _matchRepository.AddRangeAsync(matches).ConfigureAwait(false);

                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            }
            catch
            {
                //_matchLogger.Error("Bugüne ait data bulunamamıştır");
            }
           
            return matchDTOs;
        }

        public async Task<List<MatchDTO>> GetAllMatchAsync()
        {
            var matches = await _matchRepository.GetAllAsync(m => m.Include(mc => mc.AwayTeam).Include(ht => ht.HomeTeam).Include(r => r.Round).Include(s => s.Stage).Include(st => st.Status).Include(t => t.Tournament));
            var matchDTOs = matches != null ?
                (from mc in matches
                 select new MatchDTO
                 {
                     Id = mc.Id,
                     AwayTeamDTO = new AwayTeamDTO
                     {
                         MediumName = mc.AwayTeam.MediumName,
                         Name = mc.AwayTeam.Name,
                         ShortName = mc.AwayTeam.ShortName
                     },
                     HomeTeamDTO = new HomeTeamDTO
                     {
                         Name = mc.HomeTeam.Name,
                         MediumName = mc.HomeTeam.MediumName,
                         ShortName = mc.HomeTeam.ShortName,

                     },
                     CurrentMinute = mc.CurrentMinute,
                     RoundDTO = new RoundDTO
                     {
                         Name = mc.Round.Name,
                         ShortName = mc.Round.ShortName
                     },
                     StageDTO = new StageDTO
                     {
                         Name = mc.Stage.Name,
                         ShortName = mc.Stage.ShortName
                     },
                     StatusDTO = new StatusDTO
                     {
                         Name = mc.Status.Name,
                         ShortName = mc.Status.ShortName
                     },
                     Date = mc.Date,
                     TournamentDTO = new TournamentDTO
                     {
                         Name = mc.Tournament.Name,
                         ShortName = mc.Tournament.ShortName
                     },
                     Stoppage = mc.Stoppage
                 }
                 ).ToList() : null;

            return matchDTOs;
        }

        public async Task<MatchDTO> GetByIdProductAsync(int matchId)
        {
            var matches = await _matchRepository.GetByIdAsync(matchId, m => m.Include(mc => mc.AwayTeam).Include(ht => ht.HomeTeam).Include(r => r.Round).Include(s => s.Stage).Include(st => st.Status).Include(t => t.Tournament));
            if (matches == null)
            {
                return null;
            }
            else
            {
                var matchDTOs = new MatchDTO
                {
                    Id = matches.Id,
                    AwayTeamDTO = new AwayTeamDTO
                    {
                        MediumName = matches.AwayTeam.MediumName,
                        Name = matches.AwayTeam.Name,
                        ShortName = matches.AwayTeam.ShortName
                    },
                    HomeTeamDTO = new HomeTeamDTO
                    {
                        Name = matches.HomeTeam.Name,
                        MediumName = matches.HomeTeam.MediumName,
                        ShortName = matches.HomeTeam.ShortName,

                    },
                    CurrentMinute = matches.CurrentMinute,
                    RoundDTO = new RoundDTO
                    {
                        Name = matches.Round.Name,
                        ShortName = matches.Round.ShortName
                    },
                    StageDTO = new StageDTO
                    {
                        Name = matches.Stage.Name,
                        ShortName = matches.Stage.ShortName
                    },
                    StatusDTO = new StatusDTO
                    {
                        Name = matches.Status.Name,
                        ShortName = matches.Status.ShortName
                    },
                    Date = matches.Date,
                    TournamentDTO = new TournamentDTO
                    {
                        Name = matches.Tournament.Name,
                        ShortName = matches.Tournament.ShortName
                    },
                    Stoppage = matches.Stoppage

                };
                return matchDTOs;
            }
           

        }

        public async Task<MatchDTO> UpdateMatchAsync(MatchDTO matchDTO)
        {
            throw new System.NotImplementedException();

        }

        public async Task<List<MatchDTO>> UpdateRangeMatchAsync(List<MatchDTO> matchDTOs)
        {
            var matches = await _matchRepository.GetAllAsync(p => matchDTOs.Select(p => p.Date.Date).Contains(p.Date.Date), m => m.Include(mc => mc.AwayTeam.Score).Include(ht => ht.HomeTeam.Score).Include(r => r.Round).Include(s => s.Stage).Include(st => st.Status).Include(t => t.Tournament));

            foreach (var matchDTO in matchDTOs)
            {
                var match = matches.FirstOrDefault(p => p.MatchGlobalId == matchDTO.Id);

                match.Tournament.ShortName = matchDTO.TournamentDTO.ShortName;
                match.Tournament.Name = matchDTO.TournamentDTO.Name;

                match.Stoppage = matchDTO.Stoppage;

                match.Status.Name = matchDTO.StatusDTO.Name;
                match.Status.ShortName = matchDTO.StatusDTO.ShortName;

                match.Stage.Name = matchDTO.StageDTO.Name;
                match.Stage.ShortName = matchDTO.StageDTO.ShortName;

                match.Round.Name = matchDTO.RoundDTO.Name;
                match.Round.ShortName = matchDTO.RoundDTO.ShortName;

                match.CurrentMinute = matchDTO.CurrentMinute;

                match.Date = matchDTO.Date;

                match.AwayTeam.MediumName = matchDTO.AwayTeamDTO.MediumName;
                match.AwayTeam.Name = matchDTO.AwayTeamDTO.Name;
                match.AwayTeam.ShortName = matchDTO.AwayTeamDTO.ShortName;
                match.AwayTeam.Score.Current = matchDTO.AwayTeamDTO.ScoreDTO.Current;
                match.AwayTeam.Score.ExtraTime = matchDTO.AwayTeamDTO.ScoreDTO.ExtraTime;
                match.AwayTeam.Score.HalfTime = matchDTO.AwayTeamDTO.ScoreDTO.HalfTime;
                match.AwayTeam.Score.Penalties = matchDTO.AwayTeamDTO.ScoreDTO.Penalties;
                match.AwayTeam.Score.Regular = matchDTO.AwayTeamDTO.ScoreDTO.Regular;

                match.HomeTeam.MediumName = matchDTO.HomeTeamDTO.MediumName;
                match.HomeTeam.Name = matchDTO.HomeTeamDTO.Name;
                match.HomeTeam.ShortName = matchDTO.HomeTeamDTO.ShortName;
                match.HomeTeam.Score.Current = matchDTO.HomeTeamDTO.ScoreDTO.Current;
                match.HomeTeam.Score.ExtraTime = matchDTO.HomeTeamDTO.ScoreDTO.ExtraTime;
                match.HomeTeam.Score.HalfTime = matchDTO.HomeTeamDTO.ScoreDTO.HalfTime;
                match.HomeTeam.Score.Penalties = matchDTO.HomeTeamDTO.ScoreDTO.Penalties;
                match.HomeTeam.Score.Regular = matchDTO.HomeTeamDTO.ScoreDTO.Regular;

               

            }

            _matchRepository.UpdateRange(matches);

            await _unitOfWork.SaveChangeAsync();

            return null;
        }


    }
}
