using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations;

internal class UserConfiguration : BaseConfiguration<User>
{
    protected override void ConfigureStartupValues(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
            {
                Id = 1,
                Name = "name",
                Lastname = "lastname",
                Email = "mail@mail.com",
                Password = "Password1"
            },
            new User
            {
                Id = 2,
                Name = "name2",
                Lastname = "lastname2",
                Email = "mail2@mail.com",
                Password = "Password2"
            },
            new User
            {
                Id = 3,
                Name = "name3",
                Lastname = "lastname3",
                Email = "mail3@mail.com",
                Password = "Password3"
            });
    }
}