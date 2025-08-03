namespace Dkd.Infra.Repository;

/// <summary>
/// Base interface for repository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{ }

public interface IRepository
{ }
