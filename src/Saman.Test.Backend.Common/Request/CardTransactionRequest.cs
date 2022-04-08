using System;

namespace Saman.Test.Backend.Common.Request
{
    public class CardTransactionRequest
    {
        public string SourceCard { get; set; }
        public string DestinationCard { get; set; }
        public long SecondCode { get; set; }
        public long CVV2 { get; set; }
        public DateTime ExpireDate { get; set; }
        public string MobileNo { get; set; }

    }
}
