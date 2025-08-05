using Application.Classes.Pagination;
using Domain.Interfaces.Base;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        IEnumerable<T> FindAll(bool isTracking = false, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> FindByPage(PaginationParams paginationParams, bool isTracking = false, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> FindByPageWithCondition(
            PaginationParams paginationParams,
            Expression<Func<T, bool>> condition,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includes
            );
        Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default, bool isTracking = false, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition, bool isTracking = false, params Expression<Func<T, object>>[] includes);
        Task<T?> FindOneByConditionAsync(
            Expression<Func<T, bool>> condition,
            CancellationToken cancellationToken = default,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includes
            );
        Task<T?> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
