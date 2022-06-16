using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class NewUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "gabriel.torres@gmail.com", "Torres", "Gabriel", "gt12345", "6f235204-7971-40b0-9665-d5d6a97b78e9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "mauricio.delgarrando@gmail.com", "Delgarrondo", "Mauricio", "md12345", "16a7ecae-5476-4665-86f6-6eb5a3f28fd7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "romina.rodriguez@gmail.com", "Rodriguez", "Romina", "rr12345", "9914424c-48df-47ce-a0ff-aa74dafc452e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "mail@mail.com", "lastname", "name", "Password1", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "mail2@mail.com", "lastname2", "name2", "Password2", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Lastname", "Name", "Password", "Token" },
                values: new object[] { "mail3@mail.com", "lastname3", "name3", "Password3", "" });
        }
    }
}
