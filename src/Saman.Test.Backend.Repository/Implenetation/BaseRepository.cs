using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Saman.Test.Backend.Domain.Common;
using Saman.Test.Backend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Repository.Implenetation
{
    public abstract class BaseRepository<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly SamanDbContext _dbContext;

        public BaseRepository(SamanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected SamanDbContext Context => _dbContext;

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbContext.AddAsync<T>(entity);
            await _dbContext.SaveEntitiesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity.Id == 0)
                throw new Exception("!!");

            entity.ModifiedAt = DateTime.Now;
            var entry = _dbContext.Attach(entity);
            entry.State = EntityState.Modified;
            await _dbContext.SaveEntitiesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var entry = _dbContext.Attach(entity);
            entry.State = EntityState.Deleted;
            await _dbContext.SaveEntitiesAsync();
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _dbContext.Set<T>()
                                   .AsNoTracking()
                                   .SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task CreateRangeAsync(IEnumerable<T> entity)
        {
            await _dbContext.AddRangeAsync(entity);
            await _dbContext.SaveEntitiesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> entity)
        {
            _dbContext.UpdateRange(entity);
            await _dbContext.SaveEntitiesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual bool Any()
        {
            return _dbContext.Set<T>().Any();
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Any(predicate);
        }

        public abstract IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        public abstract IQueryable<T> Where();
    }
}
