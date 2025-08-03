using Microsoft.EntityFrameworkCore;

namespace Dkd.Infra.Repository;

public interface IEntityInfo
{
    void OnModelCreating(ModelBuilder modelBuilder);
}
