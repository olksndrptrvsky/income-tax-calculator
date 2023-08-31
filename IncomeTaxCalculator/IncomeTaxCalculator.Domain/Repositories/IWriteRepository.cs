using IncomeTaxCalculator.Domain.Entities.Common;

namespace IncomeTaxCalculator.Domain.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
