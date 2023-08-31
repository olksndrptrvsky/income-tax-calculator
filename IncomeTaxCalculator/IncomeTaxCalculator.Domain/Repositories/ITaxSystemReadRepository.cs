using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;

namespace IncomeTaxCalculator.Domain.Repositories
{
    public interface ITaxSystemReadRepository : IReadRepository<TaxSystem>
    {
        Task<TaxSystem?> GetTaxSystemWithBandsAsync(int id, CancellationToken cancellationToken);
    }
}
