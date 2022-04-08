using System;

namespace Saman.Test.Backend.Application.Responses
{
    public class TransactionResponse
    {
        public string SourceCrad { get; protected set; }
        public string DestinationCrad { get; protected set; }
        public string Description { get; protected set; }
        public string DigiTransaction { get; protected set; }
        public string TrackingCode { get; protected set; }
        public DateTimeOffset Date { get; protected set; }

    }
}
