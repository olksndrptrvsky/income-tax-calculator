using IncomeTaxCalculator.Domain.Entities.Common;
using IncomeTaxCalculator.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class ReadRepository<TEntity> : Repository<TEntity>, IReadRepository<TEntity> where TEntity : Entity
    {
        public ReadRepository(IncomeTaxCalculatorContext context)
            : base(context)
        {
        }

        public override async Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }
    }
}
