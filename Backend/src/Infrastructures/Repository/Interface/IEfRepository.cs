using Microsoft.EntityFrameworkCore.Query;

namespace Dkd.Infra.Repository;

/// <summary>
/// Default, full-featured Entity Framework repository interface
/// Suitable for traditional three-tier architecture development, entities must inherit from EfEntity
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IEfRepository<TEntity> : IEfBaseRepository<TEntity>
   where TEntity : EfEntity
{
    /// <summary>
    /// Execute raw SQL query
    /// </summary>
    IAdoQuerierRepository AdoQuerier { get; }

    /// <summary>
    /// Current transaction
    /// </summary>
    IDbTransaction? CurrentDbTransaction { get; }

    /// <summary>
    /// Execute raw SQL write operation
    /// </summary>
    Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute raw SQL write operation
    /// </summary>
    Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns IQueryable{TEntity}
    /// </summary>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <returns></returns>
    IQueryable<TEntity> GetAll(bool writeDb = false, bool noTracking = true);

    IQueryable<TrdEntity> GetAll<TrdEntity>(bool writeDb = false, bool noTracking = true) where TrdEntity : EfEntity;

    /// <summary>
    /// Query by Id, returns a single entity
    /// </summary>
    /// <param name="keyValue">Id</param>
    /// <param name="navigationPropertyPath">Navigation property, optional parameter</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="T:TEntity"/></returns>
    [Obsolete($"use {nameof(FetchAsync)} instead")]
    Task<TEntity?> FindAsync(long keyValue, Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query by condition, returns a single entity
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="navigationPropertyPath">Navigation property, optional parameter</param>
    /// <param name="orderByExpression">Sort field, default is primary key, optional parameter</param>
    /// <param name="ascending">Sort order, default is descending, optional parameter</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [Obsolete($"use {nameof(FetchAsync)} instead")]
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null, Expression<Func<TEntity, object>>? orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query by condition, returns a single entity
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="navigationPropertyPath">Navigation property, optional parameter</param>
    /// <param name="orderByExpression">Sort field, default is primary key, optional parameter</param>
    /// <param name="ascending">Sort order, default is descending, optional parameter</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<TEntity?> FetchAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null, Expression<Func<TEntity, object>>? orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query by condition, returns a single entity or object
    /// </summary>
    /// <typeparam name="TResult">Anonymous object</typeparam>
    /// <param name="selector">Selector</param>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="orderByExpression">Sort field, default is primary key, optional parameter</param>
    /// <param name="ascending">Sort order, default is descending, optional parameter</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<TResult?> FetchAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>>? orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a single entity
    /// </summary>
    /// <param name="entity"><see cref="T:TEntity"/></param>
    /// <param name="updatingExpressions">Array of expression trees for columns to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [Obsolete($"use {nameof(ExecuteUpdateAsync)} instead")]
    Task<int> UpdateAsync(TEntity entity, Expression<Func<TEntity, object>>[] updatingExpressions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch update
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="updatingExpression">Fields to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [Obsolete($"use {nameof(ExecuteUpdateAsync)} instead")]
    Task<int> UpdateRangeAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updatingExpression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch update
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="setPropertyCalls">Fields to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> ExecuteUpdateAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch update
    /// </summary>
    /// <param name="propertyNameAndValues">Fields and values to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> UpdateRangeAsync(Dictionary<long, List<(string propertyName, dynamic propertyValue)>> propertyNameAndValues, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="keyValue">Id</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> DeleteAsync(long keyValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch delete entities
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [Obsolete($"use {nameof(ExecuteDeleteAsync)} instead")]
    Task<int> DeleteRangeAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch delete entities
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> ExecuteDeleteAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);
}
