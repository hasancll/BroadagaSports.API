using BroadageSports.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IAwayTeamRepository AwayTeam { get; }
        IHomeTeamRepository HomeTeam { get; }
        IMatchRepository Match { get; }
        IRoundRepository Round { get; }
        IStageRepository Stage { get; }
        IStatusRepository Status { get; }
        ITournamentRepository Tournament { get; }
        Task SaveChangeAsync();
        void Commit();
    }
}
