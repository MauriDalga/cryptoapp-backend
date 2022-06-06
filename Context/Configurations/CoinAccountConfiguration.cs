using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations;

internal class CoinAccountConfiguration : BaseConfiguration<CoinAccount>
{
    protected override void ConfigureProperties(EntityTypeBuilder<CoinAccount> builder)
    {
        builder.HasKey(account => new { account.CoinId, account.UserId });
        builder.Property(account => account.Balance).HasColumnType("decimal(30,16)");
    }
    
    protected override void ConfigureRelationShips(EntityTypeBuilder<CoinAccount> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(account => account.UserId);
    }

    protected override void ConfigureStartupValues(EntityTypeBuilder<CoinAccount> builder)
    {
        builder.HasData(
            new CoinAccount
            {
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                CoinId = 2,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                CoinId = 3,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                CoinId = 1,
                Balance = 10,
                UserId = 2
            },
            new CoinAccount
            {
                CoinId = 2,
                Balance = 10,
                UserId = 2
            },
            new CoinAccount
            {
                CoinId = 3,
                Balance = 10,
                UserId = 2
            },
            new CoinAccount
            {
                CoinId = 1,
                Balance = 10,
                UserId = 3
            },
            new CoinAccount
            {
                CoinId = 2,
                Balance = 10,
                UserId = 3
            },
            new CoinAccount
            {
                CoinId = 3,
                Balance = 10,
                UserId = 3
            });
    }
}