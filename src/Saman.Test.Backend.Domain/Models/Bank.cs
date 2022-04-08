using Saman.Test.Backend.Domain.Common;
using Saman.Test.Backend.Domain.Enums;
using Saman.Test.Backend.Domain.Events;

namespace Saman.Test.Backend.Domain.Models
{
    public class Bank : Entity
    {
        public Bank()
        {

        }

        public Bank(string title, BankType type, long perCardNum)
        {
            Title = title;
            Type = type;
            PerCardNum = perCardNum;
        }

        public string Title { get; protected set; }

        public long PerCardNum { get; protected set; }

        public BankType Type { get; protected set; }


        public void SetTransaction(string sourceCard, string destinationCrad, string trackingCode, string description, string digiTransaction)
        {
            AddDomainEvent(new CardToCardTransactionDomainEvent(sourceCard, destinationCrad, trackingCode, description, digiTransaction));
        }
    }
}
