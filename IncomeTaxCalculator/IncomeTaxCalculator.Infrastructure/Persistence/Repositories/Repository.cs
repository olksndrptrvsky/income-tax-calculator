using IncomeTaxCalculator.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IncomeTaxCalculator.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IncomeTaxCalculatorContext _context;

        public Repository(IncomeTaxCalculatorContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken) =>
            FindAllAsync(_ => true, cancellationToken);
    }
}
