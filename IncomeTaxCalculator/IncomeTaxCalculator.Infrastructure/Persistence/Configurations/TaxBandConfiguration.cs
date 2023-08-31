using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Configurations
{
    internal class TaxBandConfiguration : IEntityTypeConfiguration<TaxBand>
    {
        public void Configure(EntityTypeBuilder<TaxBand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UpperLimit);
            builder.Property(x => x.LowerLimit);
            builder.Property(x => x.Rate);
        }
    }
}
