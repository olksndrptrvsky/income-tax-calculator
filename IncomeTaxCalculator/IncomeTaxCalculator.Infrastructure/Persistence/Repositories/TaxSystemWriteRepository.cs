using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using IncomeTaxCalculator.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class TaxSystemWriteRepository : WriteRepository<TaxSystem>, ITaxSystemWriteRepository
    {
        public TaxSystemWriteRepository(IncomeTaxCalculatorContext context)
            : base(context)
        {
        }

        public async Task<TaxSystem?> GetTaxSystemWithBandsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Bands).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
