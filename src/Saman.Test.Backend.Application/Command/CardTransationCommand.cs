using Saman.Test.Backend.Application.Common;
using Saman.Test.Backend.Application.Responses;
using System;

namespace Saman.Test.Backend.Application.Command
{
    public class CardTransationCommand: CommandBase<CardTransactionResponse>
    {
        public string SourceCard { get; set; }
        public string DestinationCard { get; set; }
        public long SecondCode { get; set; }
        public long CVV2 { get; set; }
        public DateTime ExpireDate { get; set; }
        public string MobileNo { get; set; }
    }
}
