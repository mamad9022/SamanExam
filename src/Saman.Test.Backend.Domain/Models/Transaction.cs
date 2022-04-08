using Saman.Test.Backend.Domain.Common;

namespace Saman.Test.Backend.Domain.Models
{
    public class Transaction : Entity
    {
        public Transaction()
        {

        }

        public Transaction(string sourceCard, string destinationCrad, string trackingCode, string description, string digiTransaction)
        {
            SourceCrad = sourceCard;
            DestinationCrad = destinationCrad;
            TrackingCode = trackingCode;
            Description = description;
            DigiTransaction = digiTransaction;
        }

        public string SourceCrad { get; protected set; }
        public string DestinationCrad { get; protected set; }
        public string Description { get; protected set; }
        public string DigiTransaction { get; protected set; }
        public string TrackingCode { get; protected set; }
    }
}
