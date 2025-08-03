namespace Dkd.Infra.Repository.EfCore;

/// <summary>
/// Base implementation of Ef repository, abstract class
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public abstract class AbstractEfBaseRepository<TDbContext, TEntity>(TDbContext dbContext) : IEfBaseRepository<TEntity>
   where TDbContext : DbContext
   where TEntity : Entity, IEfEntity<long>
{
    protected virtual TDbContext DbContext { get; } = dbContext;

    public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false, bool noTracking = true)
        => GetDbSet(writeDb, noTracking).Where(expression);

    public virtual async Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default)
    {
        var dbSet = DbContext.Set<TEntity>().AsNoTracking();
        if (writeDb)
        {
            dbSet = dbSet.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
        }

        return await dbSet.AnyAsync(whereExpression, cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default)
    {
        var dbSet = DbContext.Set<TEntity>().AsNoTracking();
        if (writeDb)
        {
            dbSet = dbSet.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
        }

        return await dbSet.CountAsync(whereExpression, cancellationToken);
    }

    public virtual Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                throw new ArgumentException($"Entity is not being tracked, cannot use this batch update method");
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Deleted)
            {
                throw new ArgumentException($"{nameof(entity)}, entity state is {nameof(entry.State)}");
            }
        }

        return UpdateInternalAsync(cancellationToken);
    }

    public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        //Get entity state
        var entry = DbContext.Entry(entity);

        //If entity is not being tracked, must specify columns to update
        if (entry.State == EntityState.Detached)
        {
            throw new ArgumentException($"Entity is not being tracked, must specify columns to update");
        }

        //Entity is marked as Added or Deleted, throw exception, ADNC should not have this state.
        if (entry.State == EntityState.Added || entry.State == EntityState.Deleted)
        {
            throw new ArgumentException($"{nameof(entity)}, entity state is {nameof(entry.State)}");
        }

        return UpdateInternalAsync(cancellationToken);
    }

    protected virtual IQueryable<TEntity> GetDbSet(bool writeDb, bool noTracking)
        => GetDbSet<TEntity>(writeDb, noTracking);

    protected virtual IQueryable<TSource> GetDbSet<TSource>(bool writeDb, bool noTracking)
        where TSource : Entity, IEfEntity<long>
    {
        if (noTracking && writeDb)
        {
            return DbContext.Set<TSource>().AsNoTracking().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
        }
        else if (noTracking)
        {
            return DbContext.Set<TSource>().AsNoTracking();
        }
        else if (writeDb)
        {
            return DbContext.Set<TSource>().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
        }
        else
        {
            return DbContext.Set<TSource>();
        }
    }

    protected async Task<int> UpdateInternalAsync(CancellationToken cancellationToken = default) =>
        await DbContext.SaveChangesAsync(cancellationToken);
}
