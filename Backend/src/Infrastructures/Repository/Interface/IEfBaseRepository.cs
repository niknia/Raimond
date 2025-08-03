namespace Dkd.Infra.Repository;

/// <summary>
/// Base interface for Entity Framework repository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IEfBaseRepository<TEntity> : IRepository<TEntity>
           where TEntity : Entity, IEfEntity<long>
{
    /// <summary>
    /// Insert a single entity
    /// </summary>
    /// <param name="entity"><see cref="T:TEntity"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch insert entities
    /// </summary>
    /// <param name="entities"><see cref="T:TEntity"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a single entity
    /// </summary>
    /// <param name="entity"><see cref="T:TEntity"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Batch update entities
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Check if entity exists based on condition
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count entities that match the condition
    /// </summary>
    /// <param name="whereExpression">Query condition</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query based on condition, returns IQueryable{TEntity}
    /// </summary>
    /// <param name="expression">Query condition</param>
    /// <param name="writeDb">Whether to use read-write database, default is false, optional parameter</param>
    /// <param name="noTracking">Whether to enable tracking, default is false, optional parameter</param>
    /// <returns></returns>
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false, bool noTracking = true);
}
