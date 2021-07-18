using BroadagaSports.API.UnitOfWork.Abstract;
using BroadageSports.Data;
using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Data.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.UnitOfWork.Concrete
{
    public class _UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly BroadageSportsContext _broadageSportsContext;
        private AwayTeamRepository _awayTeamRepository;
        private HomeTeamRepository _homeTeamRepository;
        private MatchRepository _matchRepository;
        private RoundRepository _roundRepository;
        private StageRepository _stageRepository;
        private StatusRepository _statusRepository;
        private TournamentRepository _tournamentRepository;
        #endregion

        public _UnitOfWork(BroadageSportsContext broadageSportsContext)
        {
            _broadageSportsContext = broadageSportsContext;
        }
        #region Repository Implement
        public IAwayTeamRepository AwayTeam => _awayTeamRepository = _awayTeamRepository ?? new AwayTeamRepository(_broadageSportsContext);

        public IHomeTeamRepository HomeTeam => _homeTeamRepository = _homeTeamRepository ?? new HomeTeamRepository(_broadageSportsContext);

        public IMatchRepository Match => _matchRepository = _matchRepository ?? new MatchRepository(_broadageSportsContext);

        public IRoundRepository Round => _roundRepository = _roundRepository ?? new RoundRepository(_broadageSportsContext);

        public IStageRepository Stage => _stageRepository = _stageRepository ?? new StageRepository(_broadageSportsContext);

        public IStatusRepository Status => _statusRepository = _statusRepository ?? new StatusRepository(_broadageSportsContext);

        public ITournamentRepository Tournament => _tournamentRepository = _tournamentRepository ?? new TournamentRepository(_broadageSportsContext);
        #endregion
        public void Commit()
        {
            _broadageSportsContext.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            
            await _broadageSportsContext.SaveChangesAsync();
        }
    }
}
