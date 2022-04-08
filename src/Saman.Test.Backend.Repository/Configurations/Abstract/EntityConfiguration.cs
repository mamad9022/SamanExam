using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saman.Test.Backend.Domain.Common;

namespace Saman.Test.Backend.Repository.Configurations.Abstract
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public abstract string TableName { get; }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property(e => e.Version)
                .IsRowVersion();

            builder.Ignore(b => b.DomainEvents);

            ConfigureDerived(builder);
        }

        public abstract void ConfigureDerived(EntityTypeBuilder<TEntity> builder);

    }
}
