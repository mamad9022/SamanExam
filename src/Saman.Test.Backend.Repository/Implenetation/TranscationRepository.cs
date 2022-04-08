using Saman.Test.Backend.Domain.Models;
using Saman.Test.Backend.Domain.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Saman.Test.Backend.Repository.Implenetation
{
    public class TranscationRepository : BaseRepository<Transaction>, ITranscationRepository
    {
        public TranscationRepository(SamanDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Transaction> Where(Expression<Func<Transaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Transaction> Where()
        {
            return Context.Transactions.OrderByDescending(x => x.CreatedAt).AsQueryable();
        }
    }
}
