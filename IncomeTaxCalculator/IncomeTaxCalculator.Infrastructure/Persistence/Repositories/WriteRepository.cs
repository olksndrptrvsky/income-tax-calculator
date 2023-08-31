using IncomeTaxCalculator.Domain.Entities.Common;
using IncomeTaxCalculator.Domain.Repositories;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class WriteRepository<TEntity> : Repository<TEntity>, IWriteRepository<TEntity> where TEntity : Entity
    {
        public WriteRepository(IncomeTaxCalculatorContext context)
            : base(context)
        {
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }
    }
}
