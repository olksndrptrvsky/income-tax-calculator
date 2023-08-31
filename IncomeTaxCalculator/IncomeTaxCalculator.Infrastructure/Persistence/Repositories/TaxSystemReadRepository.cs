using IncomeTaxCalculator.Domain.Entities.Aggregates.Taxes;
using IncomeTaxCalculator.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class TaxSystemReadRepository : ReadRepository<TaxSystem>, ITaxSystemReadRepository
    {
        public TaxSystemReadRepository(IncomeTaxCalculatorContext context)
            : base(context)
        {
        }

        public async Task<TaxSystem?> GetTaxSystemWithBandsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Bands).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
