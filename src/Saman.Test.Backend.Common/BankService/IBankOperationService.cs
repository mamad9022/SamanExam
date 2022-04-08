using Saman.Test.Backend.Common.Dto;
using Saman.Test.Backend.Common.Request;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Common.BankService
{
    public interface IBankOperationService
    {
        Task<BankTransactionDto> CardToCardTransaction(CardTransactionRequest request);
    }
}
