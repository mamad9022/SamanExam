using MediatR;
using Saman.Test.Backend.Domain.Events;
using Saman.Test.Backend.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.Handlers.DomainEventHandlers
{
    public class CardToCardTransactionDomainEventHandler : INotificationHandler<CardToCardTransactionDomainEvent>
    {
        private readonly ITranscationRepository _transcationRepository;

        public CardToCardTransactionDomainEventHandler(ITranscationRepository transcationRepository)
        {
            _transcationRepository = transcationRepository;
        }
        public async Task Handle(CardToCardTransactionDomainEvent notification, CancellationToken cancellationToken)
        {
            await _transcationRepository.CreateAsync(new Domain.Models.Transaction(notification.SourceCrad, notification.DestinationCrad, notification.TrackingCode, notification.Description, notification.DigiTransaction));
        }
    }
}
