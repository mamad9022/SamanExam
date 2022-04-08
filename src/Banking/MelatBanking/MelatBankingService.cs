using Saman.Test.Backend.Common.BankService;
using Saman.Test.Backend.Common.Dto;
using Saman.Test.Backend.Common.Request;
using System.Threading.Tasks;

namespace MelatBanking
{
    public class MelatBankingService : IBankOperationService
    {
        public MelatBankingService()
        {

        }
        public Task<BankTransactionDto> CardToCardTransaction(CardTransactionRequest request)
        {
            // TO DO CALL API OF MELLAT BANK AND RETURN RESULT OF IT
            var result = new BankTransactionDto
            {
                Description = "کارت به کارت از بانک ملت",
                DigiTransaction = "77777777",
                StatusCode = 200,
                TrackingCode = "9999"
            };
            return Task.FromResult(result);
        }
    }
}
