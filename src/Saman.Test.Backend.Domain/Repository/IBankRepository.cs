using LanguageExt;
using Saman.Test.Backend.Domain.Models;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Repository
{
    public interface IBankRepository:IRepositoryBase<Bank>
    {
        IUnitOfWork UnitOfWork { get; }

        Task<Bank> GetBankWith6Digit(long number);
    }
}
