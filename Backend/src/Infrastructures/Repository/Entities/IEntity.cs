namespace Dkd.Infra.Repository;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
