using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class TransactionsDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 7.26584163787004m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 1.34161639708359m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 7.91066338171608m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 4.00477166184892m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 1.70205999696502m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 1.86777729342473m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 0.712963877164713m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 1.72148134731332m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 0.490960421189683m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 8.71549683008464m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 4.85029118270612m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 4.68867718354724m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 6.49554164328042m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 7.34453042973102m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 8.1328521538112m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 4.52884790122589m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 8.31531247023941m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 8.96282364886788m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 0.481813154826731m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 6.09346617067734m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 2.66482734833066m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 9.68432429627736m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 1.62191355355222m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 1.60955593039421m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 2.95856475103206m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 3.15889195435753m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 4.26988808662951m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 4.53394708579231m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 5.68663599230682m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 8.80278669766536m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "247d8cbf-e23f-4ef4-a06b-6a83dec27520", "69350120d76b4e70be264cc851649442" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "1f6e1420-8fd3-47eb-882a-febc3cec4263", "452887066605484eb9dd6a4c2e5762eb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "ca085d5a-dd8b-4903-9259-13a7563dd249", "ee1058d3d29f47258cfa8770427465dd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 3.64730900000618m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 8.57240883895451m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 1.73677566535256m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 8.39667407323132m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 6.57065754548116m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 5.43330248430767m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 1.93929585923548m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 1.73351118866005m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 9.3220418176228m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 4.75088161392274m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 2.54635651896306m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 7.82244046494325m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 3.71516232364589m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 5.6387781237608m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 5.47081869673929m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 8.38739319736387m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 5.84611662024655m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 0.374692161701902m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 3.68494154724381m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 5.12901618488232m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 4.73541128095114m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 9.59503637081357m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 3.76176697807559m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 8.90773182594372m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 6.3417129821418m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 8.51866338446213m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 1.90576386698029m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 7.15466425716295m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 5.70920110642024m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 4.45368219350908m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "3dcfd273-2ccd-4d98-8a72-ba578eabc8da", "23a89a95b93d452f9c6f6d135158ee88" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "ccba7e53-998e-47b3-ba96-dc5f65c3c95d", "150fffd1e0f0459683dc59ec0674b8f5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "0f3ad323-96ea-40be-8f43-75ce281e130e", "4d69d5cf4c0a4184afe4726500261215" });
        }
    }
}
