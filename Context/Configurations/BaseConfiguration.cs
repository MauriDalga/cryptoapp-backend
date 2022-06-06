using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureProperties(builder);
            ConfigureRelationShips(builder);
            ConfigureStartupValues(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<T> builder)
        {
        }

        protected virtual void ConfigureRelationShips(EntityTypeBuilder<T> builder)
        {
        }

        protected virtual void ConfigureStartupValues(EntityTypeBuilder<T> builder)
        {
        }
    }
}