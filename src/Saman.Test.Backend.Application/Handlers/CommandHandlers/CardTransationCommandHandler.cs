using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Saman.Test.Backend.Application.Command;
using Saman.Test.Backend.Application.Responses;
using Saman.Test.Backend.Application.Strategy;
using Saman.Test.Backend.Common.Request;
using Saman.Test.Backend.Domain.Exceptions;
using Saman.Test.Backend.Domain.Models;
using Saman.Test.Backend.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.Handlers.CommandHandlers
{
    public class CardTransationCommandHandler : IRequestHandler<CardTransationCommand, CardTransactionResponse>
    {
        private readonly IBankRepository _bankRepository;
        private IMapper _mapper;
        public CardTransationCommandHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<CardTransactionResponse> Handle(CardTransationCommand request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetBankWith6Digit(long.Parse(request.SourceCard.Substring(0, 6)));

            if (bank == null)
                throw new SamanException(Domain.Common.ErrorCode.BadRequest, customMessage: "Invalid source card");

            #region Detect Strategy Interface

            ServiceStrategyContext context = new ServiceStrategyContext();

            context.DetectServices(bank.Type);

            #endregion Detect Strategy Interface

            var result = await context.CardToCardTransaction(_mapper.Map<CardTransactionRequest>(request));

            bank.SetTransaction(request.SourceCard, request.DestinationCard, result.TrackingCode, result.Description, result.DigiTransaction);

            await _bankRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return _mapper.Map<CardTransactionResponse>(result);
        }
    }
}
