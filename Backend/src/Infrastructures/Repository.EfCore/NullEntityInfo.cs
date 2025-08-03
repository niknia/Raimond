namespace Dkd.Infra.Repository.EfCore;

public class NullEntityInfo : IEntityInfo
{
    public void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
