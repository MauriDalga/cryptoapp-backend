using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class AddDeviceToken2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 3.48353465389977m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 4.72942559085091m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 8.09723333828842m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 6.40891381169752m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 7.4257361912946m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 9.36456182156556m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 8.46973170231963m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 9.97410916829032m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 7.01363255559855m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 8.34829372102057m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 7.61497648065775m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 1.54993823523514m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 4.54855669114043m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 6.61196168865759m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 6.3646468773296m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 6.56324494636157m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 1.96661723780273m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 8.7037108418043m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 1.36377530464522m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 2.79445435233093m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 0.487595991411215m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 5.65785741373878m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 4.68536486579029m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 8.2743214233183m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 5.97881805433652m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 1.28516982730992m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 4.90446485273362m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 4.7340854705328m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 5.88273141516912m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 6.53107884688385m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeviceToken", "Token", "WalletAddress" },
                values: new object[] { "", "fc7d4fe9-07c3-4dee-ba75-5d57f75452f5", "3ef48e77031849bbae63ae2c24efce06" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeviceToken", "Token", "WalletAddress" },
                values: new object[] { "", "b95b7ffb-1d4a-4ccc-8fb6-575135e124a4", "a2ac158202d446cebe56d7583254c19a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeviceToken", "Token", "WalletAddress" },
                values: new object[] { "", "7fd7920d-d21f-448c-838e-79b5c3a3e7fa", "016130dae05540b7a12422f10f6d68e8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 2.85662452787248m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 2.80384974219754m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 0.941393386832424m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 4.23306867370626m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 6.0341860726693m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Balance",
                value: 0.956765360759056m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Balance",
                value: 9.27198956536899m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Balance",
                value: 4.48126592085139m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Balance",
                value: 8.92643496084213m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Balance",
                value: 4.25663002077154m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Balance",
                value: 5.4175758391905m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Balance",
                value: 3.7476982876014m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Balance",
                value: 3.41497042684968m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Balance",
                value: 3.64052923461782m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Balance",
                value: 9.49090172905991m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Balance",
                value: 3.95904083765306m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Balance",
                value: 3.83966099639848m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Balance",
                value: 5.49002953088932m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Balance",
                value: 8.49090597159641m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Balance",
                value: 5.29816270657429m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Balance",
                value: 9.06931243816348m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Balance",
                value: 4.20651665312055m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Balance",
                value: 1.40807306631976m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Balance",
                value: 1.30572740683808m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Balance",
                value: 4.10612433491144m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Balance",
                value: 3.24026316863809m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Balance",
                value: 3.54139498908204m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Balance",
                value: 4.58559631175557m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Balance",
                value: 2.01062325731396m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Balance",
                value: 4.85679581081054m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "b437c547-2823-42ad-80ab-08872fdf2f43", "70532549fc90470dbd2434a218b1c42e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "1d3bef4a-8da4-47c6-94d4-9ecebf5f4d87", "4558ed489e534b5ebf087755b6c5d88d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "e2608c9d-cc4f-4287-b793-2c6f95fa9a7e", "fa3163f482054d9b8d8daded49fa0cfb" });
        }
    }
}
