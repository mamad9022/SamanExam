using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saman.Test.Backend.Domain.Models;

namespace Saman.Test.Backend.Repository.Configurations.Abstract
{
    public class TransactionConfiguration : EntityConfiguration<Transaction>
    {
        public override string TableName => "Transactions";

        public override void ConfigureDerived(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);  

            builder.Property(x=>x.SourceCrad).IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DestinationCrad).IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired()
            .HasMaxLength(500);

            builder.Property(x => x.TrackingCode).IsRequired()
            .HasMaxLength(50);

            builder.Property(x => x.DigiTransaction).IsRequired()
            .HasMaxLength(50);

        }
    }
}
