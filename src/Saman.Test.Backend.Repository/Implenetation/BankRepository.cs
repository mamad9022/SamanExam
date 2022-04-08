using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Saman.Test.Backend.Domain.Models;
using Saman.Test.Backend.Domain.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Repository.Implenetation
{
    public class BankRepository : BaseRepository<Bank>, IBankRepository
    {
        private readonly SamanDbContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }
        public BankRepository(SamanDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Bank> GetBankWith6Digit(long number)
        {
           return await Context.Banks.FirstOrDefaultAsync(x => x.PerCardNum == number);
        }

        public override IQueryable<Bank> Where(Expression<Func<Bank, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Bank> Where()
        {
            throw new NotImplementedException();
        }
    }
}
