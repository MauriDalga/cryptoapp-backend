using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations;

internal class TransactionAccountConfiguration : BaseConfiguration<Transaction>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(transaction => transaction.Amount).HasColumnType("decimal(30,16)");
    }
}