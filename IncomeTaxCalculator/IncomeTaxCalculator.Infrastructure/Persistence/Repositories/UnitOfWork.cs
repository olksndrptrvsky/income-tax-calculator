using IncomeTaxCalculator.Domain.Repositories;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IncomeTaxCalculatorContext _context;

        public UnitOfWork(IncomeTaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
