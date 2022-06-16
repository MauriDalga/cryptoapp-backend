using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class AddDeviceToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WalletAddress",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 8.89852154851818m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 8.67242227087659m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 1.62442126058512m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 8.24343294395264m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 0.833777716093151m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 0.828921037360211m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 8.3262118617443m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 3.99695524967747m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 6.93489377384762m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 3.11418654496572m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 8.29762224955673m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 6.13078404012289m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 5.14130883147819m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 5.27265638624043m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 1.61420478684411m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 9.30016662772329m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 2.23071538770452m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 8.19252139423216m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 4.93483819818611m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 6.14030149981244m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 5.22169907653844m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 8.29995548002991m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 9.81892879028598m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 7.69541807464466m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 8.24720637445213m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 2.30850947632977m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 8.9770883116225m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 3.18917551072254m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 8.99130862837568m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 2.56764851875694m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "556ad554-c127-4b3e-8758-31ac954351c4", "b9853388211247c5bc81caadabf18fd7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "63f36c55-0dff-42d2-bae7-50aced470927", "a9ff9b4dc39645fba6166733fd64e8b9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "cc3cdad5-ca99-4b18-80c5-c499bb77e440", "766d0d9c07ee494a95fa93e8b4a09e92" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletAddress",
                table: "Transactions");

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
    }
}
