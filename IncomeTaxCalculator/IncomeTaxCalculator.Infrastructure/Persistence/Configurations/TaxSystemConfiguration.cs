using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Configurations
{
    internal class TaxSystemConfiguration : IEntityTypeConfiguration<TaxSystem>
    {
        public void Configure(EntityTypeBuilder<TaxSystem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(500);

            builder.HasMany(x => x.Bands)
                .WithOne(x => x.TaxSystem);
        }
    }
}
