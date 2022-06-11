using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class WalletAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WalletAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "6a386bae-a82a-4d27-8612-ee3d174fb3b6", "b90e1d4d017a4ba59edd8e1bbef91d5e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "80dc3589-0c41-4bfe-b4cc-07d8c67e8a57", "51c81c258bfd4a53aa3996b95f3845e1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "be57c8e6-4f2c-482a-8ee6-7f144788cbd6", "755e92c1a8b04e34a35d8398ece12827" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletAddress",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Token",
                value: "6f235204-7971-40b0-9665-d5d6a97b78e9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Token",
                value: "16a7ecae-5476-4665-86f6-6eb5a3f28fd7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Token",
                value: "9914424c-48df-47ce-a0ff-aa74dafc452e");
        }
    }
}
