using Domain.Common;
using Domain.Investors;

namespace Persistence.Shared;

public interface IDatabaseContext
{
    Microsoft.EntityFrameworkCore.DbSet<Investor> Investors { get; set; }
    Microsoft.EntityFrameworkCore.DbSet<T> Set<T>() where T : class, IEntity;
    void Save();
}