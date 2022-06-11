using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class RelationCoinAccountAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "CoinAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "Balance",
                value: 1.22379776351143m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "Balance",
                value: 2.57662171457179m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "Balance",
                value: 7.21218863497048m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "Balance",
                value: 3.30903498012092m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Balance",
                value: 3.96938791549471m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Balance",
                value: 2.40503258277717m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 1 },
                column: "Balance",
                value: 9.66098720150626m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 2 },
                column: "Balance",
                value: 3.76883064482281m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "Balance",
                value: 4.7537159013292m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 1 },
                column: "Balance",
                value: 8.87560783793404m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 2 },
                column: "Balance",
                value: 0.281722411061768m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 3 },
                column: "Balance",
                value: 1.97714700511996m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 1 },
                column: "Balance",
                value: 9.30808325752184m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 2 },
                column: "Balance",
                value: 7.50775421721834m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 3 },
                column: "Balance",
                value: 8.99903870721686m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 1 },
                column: "Balance",
                value: 3.1757178770482m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 2 },
                column: "Balance",
                value: 2.81392866612316m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 3 },
                column: "Balance",
                value: 8.85373893957326m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 1 },
                column: "Balance",
                value: 4.1708212566645m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 2 },
                column: "Balance",
                value: 1.5420214592373m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 3 },
                column: "Balance",
                value: 4.75654216674907m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 1 },
                column: "Balance",
                value: 7.75738069815318m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 2 },
                column: "Balance",
                value: 8.47550717283521m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 3 },
                column: "Balance",
                value: 8.64218700370524m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 1 },
                column: "Balance",
                value: 4.87095226341205m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 2 },
                column: "Balance",
                value: 5.72233925980462m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 3 },
                column: "Balance",
                value: 2.76426164409036m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 1 },
                column: "Balance",
                value: 5.60433013615933m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 2 },
                column: "Balance",
                value: 8.00497094532189m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 3 },
                column: "Balance",
                value: 9.5875253844491m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "01ba2a22-1507-40a3-a672-c465a10736ff", "0493caaf7afd4f6aa106dc24b81971ef" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "e6f77a97-683c-4fe0-bfc2-12d8c2a7a989", "f1929faaf9b14da2874c2b31436cd3ed" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "4b5791f0-264d-4c26-8a4a-3532fe7842a1", "fcdefded71cd4cfebf7621da701fe03a" });

            migrationBuilder.CreateIndex(
                name: "IX_CoinAccounts_UserId1",
                table: "CoinAccounts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinAccounts_Users_UserId1",
                table: "CoinAccounts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinAccounts_Users_UserId1",
                table: "CoinAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CoinAccounts_UserId1",
                table: "CoinAccounts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CoinAccounts");

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

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 1 },
                column: "Balance",
                value: 9.14376926773956m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 2 },
                column: "Balance",
                value: 9.74450823205167m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 3 },
                column: "Balance",
                value: 2.94105906108655m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 1 },
                column: "Balance",
                value: 0.539755755288008m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 2 },
                column: "Balance",
                value: 9.16858514743612m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 3 },
                column: "Balance",
                value: 9.28896874731942m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 1 },
                column: "Balance",
                value: 6.71333476305775m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 2 },
                column: "Balance",
                value: 8.76652403542934m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 3 },
                column: "Balance",
                value: 4.02284166276941m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 1 },
                column: "Balance",
                value: 3.76427986769159m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 2 },
                column: "Balance",
                value: 7.84341872513289m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 3 },
                column: "Balance",
                value: 4.66488479117756m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 1 },
                column: "Balance",
                value: 6.25817634138527m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 2 },
                column: "Balance",
                value: 6.52734674348795m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 3 },
                column: "Balance",
                value: 5.71187018974554m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 1 },
                column: "Balance",
                value: 3.18480789271887m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 2 },
                column: "Balance",
                value: 1.97183804272179m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 3 },
                column: "Balance",
                value: 5.7874205251442m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 1 },
                column: "Balance",
                value: 7.75039027947522m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 2 },
                column: "Balance",
                value: 9.50166075938977m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 3 },
                column: "Balance",
                value: 2.66265443074525m);

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
    }
}
