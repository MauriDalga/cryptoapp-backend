using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Context;

public class MyContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Coin> Coins { get; set; }

    public DbSet<CoinAccount> CoinAccounts { get; set; }

    public MyContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var executionAssembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(executionAssembly);
    }
}