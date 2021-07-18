using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Entity.Entities;
using BroadageSports.Entity.Includable.Abstact;
using BroadageSports.Entity.Includable.Extension;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Repository.Concrete
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : BaseEntity
    {
        protected readonly DbSet<Tentity> _dbSet;
        public BaseRepository(BroadageSportsContext broadageSportsContext)
        {
            _dbSet = broadageSportsContext.Set<Tentity>();
            
        }

        public async Task<Tentity> AddAsync(Tentity tentity)
        {
            await _dbSet.AddRangeAsync(tentity).ConfigureAwait(false);

            return tentity;
        }

        public async Task<IEnumerable<Tentity>> AddRangeAsync(IEnumerable<Tentity> tentities)
        {
           

            await _dbSet.AddRangeAsync(tentities).ConfigureAwait(false);

            return tentities;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.IncludeMultiple(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(ExpressionStarter<Tentity> expressionStarter, Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.Where(expressionStarter).IncludeMultiple(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> expression, Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.Where(expression).IncludeMultiple(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Tentity> GetByIdAsync(int id, Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.IncludeMultiple(predicate).FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public Tentity Update(Tentity tentity)
        {
            _dbSet.Update(tentity);

            return tentity;
        }

        public IEnumerable<Tentity> UpdateRange(IEnumerable<Tentity> tentities)
        {
            _dbSet.UpdateRange(tentities);

            return tentities;
        }
    }
}
