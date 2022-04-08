using LanguageExt;
using Saman.Test.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Repository
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetAsync(long id);

        Task CreateRangeAsync(IEnumerable<T> entity);

        Task UpdateRangeAsync(IEnumerable<T> entity);

        Task<IEnumerable<T>> GetListAsync();

        bool Any();

        bool Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        IQueryable<T> Where();

    }
}
