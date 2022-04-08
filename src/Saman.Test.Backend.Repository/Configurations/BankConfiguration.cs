using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saman.Test.Backend.Domain.Models;
using Saman.Test.Backend.Repository.Configurations.Abstract;

namespace Saman.Test.Backend.Repository.Configurations
{
    public class BankConfiguration : EntityConfiguration<Bank>
    {
        public override string TableName => "Banks";

        public override void ConfigureDerived(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id);
         
            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(50);
        }
    }
}
