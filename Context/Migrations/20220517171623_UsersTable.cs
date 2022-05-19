using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class UsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { 1, "mail@mail.com", "lastname", "name", "Password1", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { 2, "mail2@mail.com", "lastname2", "name2", "Password2", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { 3, "mail3@mail.com", "lastname3", "name3", "Password3", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
