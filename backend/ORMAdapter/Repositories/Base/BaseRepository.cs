using Application.Classes.Pagination;
using Application.Interfaces.Repositories.Base;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using ORMAdapter.Contexts;
using System.Linq.Expressions;

namespace ORMAdapter.Repositories.Base
{
    public class BaseRepository<T>(WarehouseDbContext context) : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly WarehouseDbContext _context = context;

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default) => await _context.Set<T>().CountAsync(cancellationToken);

        public virtual IEnumerable<T> FindAll(bool isTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> entities = _context.Set<T>();

            if (!isTracking)
                entities = entities.AsNoTracking();

            if (!entities.Any()) return [];

            return _applyIncludes(entities, includes).AsEnumerable();
        }

        public virtual IEnumerable<T> FindByPage(PaginationParams paginationParams, bool isTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> entitiesQuery = _context.Set<T>();

            if (!isTracking)
                entitiesQuery = entitiesQuery.AsNoTracking();

            if (!entitiesQuery.Any()) return [];

            entitiesQuery = _applyIncludes(entitiesQuery, includes);

            var pagedEntities = entitiesQuery
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);

            return pagedEntities.AsEnumerable();
        }

        public virtual IEnumerable<T> FindByPageWithCondition(
            PaginationParams paginationParams,
            Expression<Func<T, bool>> condition,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> entitiesQuery = _context.Set<T>();

            if (!isTracking)
                entitiesQuery = entitiesQuery.AsNoTracking();

            if (!entitiesQuery.Any()) return [];

            entitiesQuery = _applyIncludes(entitiesQuery, includes);

            var pagedEntities = entitiesQuery
                .Where(condition)
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);

            return pagedEntities.AsEnumerable();
        }

        public virtual async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default, bool isTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> entityQuery = _context.Set<T>();

            if (!isTracking)
                entityQuery = entityQuery.AsNoTracking();

            entityQuery = _applyIncludes(entityQuery, includes);

            return await entityQuery.FirstOrDefaultAsync((entity) => entity.Id == id);
        }

        public virtual IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition, bool isTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> entityQuery = _context.Set<T>();

            if (!isTracking)
                entityQuery = entityQuery.AsNoTracking();

            entityQuery = _applyIncludes(entityQuery, includes);

            return entityQuery.Where(condition).AsEnumerable();
        }

        public virtual async Task<T?> FindOneByConditionAsync(
            Expression<Func<T, bool>> condition,
            CancellationToken cancellationToken = default,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> entityQuery = _context.Set<T>();

            if (!isTracking)
                entityQuery = entityQuery.AsNoTracking();

            entityQuery = _applyIncludes(entityQuery, includes);

            return await entityQuery.FirstOrDefaultAsync(condition, cancellationToken);
        }
        public virtual async Task<T?> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context
                    .Set<T>()
                    .AddAsync(entity, cancellationToken);

                await SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public virtual async Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Set<T>().Update(entity);

                await SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);

                await SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context
                    .Set<T>()
                    .Remove(entity);

                await SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _context
                .SaveChangesAsync(cancellationToken);

        protected IQueryable<T> _applyIncludes(IQueryable<T> query, Expression<Func<T, object>>[] includes)
        {
            for (var i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }

            return query;
        }
    }
}
