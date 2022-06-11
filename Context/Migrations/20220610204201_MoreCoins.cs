using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class MoreCoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "Balance",
                value: 2.35145598743849m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "Balance",
                value: 5.62535211795362m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "Balance",
                value: 5.97547596512854m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "Balance",
                value: 7.06177057940322m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Balance",
                value: 6.82582346245403m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Balance",
                value: 3.4822344481341m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 1 },
                column: "Balance",
                value: 5.16377002448183m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 2 },
                column: "Balance",
                value: 8.90695960592594m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "Balance",
                value: 5.56133837336033m);

            migrationBuilder.InsertData(
                table: "CoinAccounts",
                columns: new[] { "CoinId", "UserId", "Balance" },
                values: new object[,]
                {
                    { 4, 1, 9.14376926773956m },
                    { 4, 2, 9.74450823205167m },
                    { 4, 3, 2.94105906108655m },
                    { 5, 1, 0.539755755288008m },
                    { 5, 2, 9.16858514743612m },
                    { 5, 3, 9.28896874731942m },
                    { 6, 1, 6.71333476305775m },
                    { 6, 2, 8.76652403542934m },
                    { 6, 3, 4.02284166276941m },
                    { 7, 1, 3.76427986769159m },
                    { 7, 2, 7.84341872513289m },
                    { 7, 3, 4.66488479117756m },
                    { 8, 1, 6.25817634138527m },
                    { 8, 2, 6.52734674348795m },
                    { 8, 3, 5.71187018974554m },
                    { 9, 1, 3.18480789271887m },
                    { 9, 2, 1.97183804272179m },
                    { 9, 3, 5.7874205251442m },
                    { 10, 1, 7.75039027947522m },
                    { 10, 2, 9.50166075938977m },
                    { 10, 3, 2.66265443074525m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "f323110f-c0d5-4331-8cc7-ab3e28adb066", "bc120c5185914777af04c328e66a7681" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "149a950f-16e9-47c2-a4eb-35ba29427b87", "eb6909ff45f84734bc74ff56e2174d53" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "04f193b6-00d4-431a-bb83-c66878ce13dc", "14eb5f9b91f04ba88e03982adbf80dd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 1 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 2 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "Balance",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "af4d4fb7-13d2-49b0-9fa5-1590e0b08a51", "db3b9150456e4b278368c1926a40a868" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "c2cbb345-e035-45c7-8c56-141c2787479a", "2c737d27e09640fca757a4e56aafd315" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "ae25369e-555a-4256-a045-7f6330bd0729", "619293adb02f401e96ab67c5c36ae943" });
        }
    }
}
