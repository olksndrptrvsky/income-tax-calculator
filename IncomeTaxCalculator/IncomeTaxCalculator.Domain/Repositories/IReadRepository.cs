using IncomeTaxCalculator.Domain.Entities.Common;
using System.Linq.Expressions;

namespace IncomeTaxCalculator.Domain.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
    }
}
