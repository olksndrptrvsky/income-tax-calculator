using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;

namespace IncomeTaxCalculator.Domain.Repositories
{
    public interface ITaxSystemWriteRepository : IWriteRepository<TaxSystem>
    {
        Task<TaxSystem?> GetTaxSystemWithBandsAsync(int id, CancellationToken cancellationToken);
    }
}
