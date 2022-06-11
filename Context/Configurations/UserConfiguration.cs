using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations;

internal class UserConfiguration : BaseConfiguration<User>
{
    protected override void ConfigureStartupValues(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                Name = "Gabriel",
                Lastname = "Torres",
                Email = "gabriel.torres@gmail.com",
                Password = "gt12345",
                Token = Guid.NewGuid().ToString()
            },
            new User
            {
                Id = 2,
                Name = "Mauricio",
                Lastname = "Delgarrondo",
                Email = "mauricio.delgarrando@gmail.com",
                Password = "md12345",
                Token = Guid.NewGuid().ToString()
            },
            new User
            {
                Id = 3,
                Name = "Romina",
                Lastname = "Rodriguez",
                Email = "romina.rodriguez@gmail.com",
                Password = "rr12345",
                Token = Guid.NewGuid().ToString()
            });
    }
}