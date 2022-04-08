using AyndehBanking;
using MelatBanking;
using Saman.Test.Backend.Common.BankService;
using Saman.Test.Backend.Common.Dto;
using Saman.Test.Backend.Common.Request;
using Saman.Test.Backend.Domain.Enums;
using SamanBanking;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.Strategy
{
    public class ServiceStrategyContext
    {
        private IBankOperationService _service;

        public ServiceStrategyContext()
        {

        }

        public IBankOperationService DetectServices(BankType bankType)
        {
            switch (bankType)
            {
                case BankType.Ayandeh:
                    return _service = new AyndehBankingService();

                case BankType.Melat:
                    return _service = new MelatBankingService();

                case BankType.Saman:
                    return _service = new SamanBankingService();

                default:
                    Log.Error("service Method Argument out of range Exception");
                    throw new ArgumentOutOfRangeException();
            }
        }

       public Task<BankTransactionDto> CardToCardTransaction(CardTransactionRequest request) => _service.CardToCardTransaction(request);
    }
}
