using BroadageSports.Entity.Entities;
using BroadageSports.Entity.Includable.Abstact;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BroadageSports.Data.Repository.Abstract
{
    public interface IBaseRepository<Tentity> where Tentity : BaseEntity
    {
        Task<Tentity> AddAsync(Tentity tentity);
        Task<Tentity> GetByIdAsync(int id, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> AddRangeAsync(IEnumerable<Tentity> tentities);
        Task<IEnumerable<Tentity>> GetAllAsync(Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> GetAllAsync(ExpressionStarter<Tentity> expressionStarter, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> expression, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Tentity Update(Tentity tentity);
        IEnumerable<Tentity> UpdateRange(IEnumerable<Tentity> tentities);
    }
}
