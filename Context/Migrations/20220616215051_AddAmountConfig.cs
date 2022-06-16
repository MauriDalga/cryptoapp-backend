using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class AddAmountConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(30,16)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 8.30785789804478m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 6.76956675224134m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 2.4212871394943m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 9.51352836619861m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 8.63558646322729m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 9.84517400486148m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 2.80551456981865m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 6.31974621740374m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 5.56450898563337m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 2.78348253499073m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 9.80747958972714m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 8.13130180269431m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 4.78671777640117m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 6.31624992995622m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 7.1827434823304m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 1.96035712004414m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 1.11582413004241m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 4.37126571772669m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 0.701598526432998m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 7.49948724849495m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 2.01400559725727m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 2.36005863923382m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 4.73705007709042m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 6.55637005936734m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 3.27414288382406m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 5.2948099717768m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 8.01502641675601m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 9.31462369504148m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 5.59526625463671m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 4.43489162896301m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "998b74f7-1fa8-4fe5-87c5-4edb2fd1d073", "9fb1d1b9859f4e3c9b2d3b37bc41327d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "7a4ae1de-d106-4d31-88cb-0472f1e45206", "75376970c6ff4803afa80e036ee3e19e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "c7c3e34d-66f2-4962-a7c4-657797dfc5cb", "a9e61f293ef244a8bf0f865dec1f49ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,16)");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 6.96325844322642m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 4.82880791913948m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 1.63225870663153m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 1.8452997804859m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 2.30466265356507m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 6.29912442375473m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 0.309168810603567m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 0.511653498089704m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 3.65542230930269m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 7.82416378234756m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 9.56302982606238m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 3.79952775488604m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 0.844479254968388m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 4.35245969452666m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 7.89172713631091m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 4.85645656500985m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 2.53466020195406m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 0.327165069325437m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 8.51708670153793m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 1.61485486210483m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 8.39258984627668m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 8.68548659713021m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 6.79734202990074m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 0.14029936350326m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 8.00813911027132m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 9.12419849667952m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 9.89925404523435m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 0.592792074049425m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 7.53512294636082m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 2.14488517278621m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "879f6859-5193-4318-882b-de4e7abb7236", "ff039a866a36403e952ab9e8af30a724" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "85c83e46-87ad-432a-a23a-17d15c16831f", "8ba0b1152625409bbd797dd2473afa79" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "0aa8e190-0e48-4cbf-9971-ddc0bb22011e", "2956a6f281dd48febeb2f12b86f1b032" });
        }
    }
}
