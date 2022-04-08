using MediatR;

namespace Saman.Test.Backend.Domain.Events
{
    public class CardToCardTransactionDomainEvent : INotification
    {
        public string SourceCrad { get; }
        public string DestinationCrad { get; }
        public string Description { get; }
        public string DigiTransaction { get; }
        public string TrackingCode { get; }

        public CardToCardTransactionDomainEvent(string sourceCard, string destinationCrad, string trackingCode, string description, string digiTransaction)
        {
            SourceCrad = sourceCard;
            DestinationCrad = destinationCrad;
            TrackingCode = trackingCode;
            Description = description;
            DigiTransaction = digiTransaction;
        }
    }
}
