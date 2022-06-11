using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations;

internal class CoinAccountConfiguration : BaseConfiguration<CoinAccount>
{
    protected override void ConfigureProperties(EntityTypeBuilder<CoinAccount> builder)
    {
        builder.Property(account => account.Balance).HasColumnType("decimal(30,16)");
    }

    protected override void ConfigureStartupValues(EntityTypeBuilder<CoinAccount> builder)
    {
        builder.HasData(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 2,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 3,
                CoinId = 3,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 4,
                CoinId = 4,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 5,
                CoinId = 5,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 6,
                CoinId = 6,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 7,
                CoinId = 7,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 8,
                CoinId = 8,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 9,
                CoinId = 9,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 10,
                CoinId = 10,
                Balance = RandomDecimal(0, 10),
                UserId = 1
            },
            new CoinAccount
            {
                Id = 11,
                CoinId = 1,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 12,
                CoinId = 2,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 13,
                CoinId = 3,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 14,
                CoinId = 4,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 15,
                CoinId = 5,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 16,
                CoinId = 6,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 17,
                CoinId = 7,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 18,
                CoinId = 8,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 19,
                CoinId = 9,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 20,
                CoinId = 10,
                Balance = RandomDecimal(0, 10),
                UserId = 2
            },
            new CoinAccount
            {
                Id = 21,
                CoinId = 1,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 22,
                CoinId = 2,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 23,
                CoinId = 3,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 24,
                CoinId = 4,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 25,
                CoinId = 5,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 26,
                CoinId = 6,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 27,
                CoinId = 7,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 28,
                CoinId = 8,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 29,
                CoinId = 9,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            },
            new CoinAccount
            {
                Id = 30,
                CoinId = 10,
                Balance = RandomDecimal(0, 10),
                UserId = 3
            });
    }

    private static decimal RandomDecimal(float min, float max)
    {
        Random random = new();
        double val = (random.NextDouble() * (max - min) + min);
        return (decimal)val;
    }
}