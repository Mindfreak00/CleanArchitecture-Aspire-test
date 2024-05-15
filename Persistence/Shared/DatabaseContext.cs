//using System.Data.Entity;
//using Castle.Core.Configuration;

using Castle.Core.Resource;
using Domain.Common;
using Domain.Investors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Investors;

namespace Persistence.Shared;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public Microsoft.EntityFrameworkCore.DbSet<Investor> Investors { get; set; }

    private readonly IConfiguration _configuration;


    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;

        Database.EnsureCreated();
    }

    public new Microsoft.EntityFrameworkCore.DbSet<T> Set<T>() where T : class, IEntity
    {
        return base.Set<T>();
    }

    public void Save()
    {
        this.SaveChanges();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("CleanArchitectureCore");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new InvestorConfiguration().Configure(modelBuilder.Entity<Investor>());
    }
}