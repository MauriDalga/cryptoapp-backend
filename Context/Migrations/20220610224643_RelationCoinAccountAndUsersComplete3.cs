using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class RelationCoinAccountAndUsersComplete3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinAccounts_Users_UserId1",
                table: "CoinAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinAccounts",
                table: "CoinAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CoinAccounts_UserId1",
                table: "CoinAccounts");

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 3 });

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

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CoinAccounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CoinAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinAccounts",
                table: "CoinAccounts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CoinAccounts",
                columns: new[] { "Id", "Balance", "CoinId", "UserId" },
                values: new object[,]
                {
                    { 1, 3.64730900000618m, 1, 1 },
                    { 2, 8.57240883895451m, 2, 1 },
                    { 3, 1.73677566535256m, 3, 1 },
                    { 4, 8.39667407323132m, 4, 1 },
                    { 5, 6.57065754548116m, 5, 1 },
                    { 6, 5.43330248430767m, 6, 1 },
                    { 7, 1.93929585923548m, 7, 1 },
                    { 8, 1.73351118866005m, 8, 1 },
                    { 9, 9.3220418176228m, 9, 1 },
                    { 10, 4.75088161392274m, 10, 1 },
                    { 11, 2.54635651896306m, 1, 2 },
                    { 12, 7.82244046494325m, 2, 2 },
                    { 13, 3.71516232364589m, 3, 2 },
                    { 14, 5.6387781237608m, 4, 2 },
                    { 15, 5.47081869673929m, 5, 2 },
                    { 16, 8.38739319736387m, 6, 2 },
                    { 17, 5.84611662024655m, 7, 2 },
                    { 18, 0.374692161701902m, 8, 2 },
                    { 19, 3.68494154724381m, 9, 2 },
                    { 20, 5.12901618488232m, 10, 2 },
                    { 21, 4.73541128095114m, 1, 3 },
                    { 22, 9.59503637081357m, 2, 3 },
                    { 23, 3.76176697807559m, 3, 3 },
                    { 24, 8.90773182594372m, 4, 3 },
                    { 25, 6.3417129821418m, 5, 3 },
                    { 26, 8.51866338446213m, 6, 3 },
                    { 27, 1.90576386698029m, 7, 3 },
                    { 28, 7.15466425716295m, 8, 3 },
                    { 29, 5.70920110642024m, 9, 3 },
                    { 30, 4.45368219350908m, 10, 3 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CoinAccounts_CoinId",
                table: "CoinAccounts",
                column: "CoinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinAccounts",
                table: "CoinAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CoinAccounts_CoinId",
                table: "CoinAccounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CoinAccounts");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "CoinAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinAccounts",
                table: "CoinAccounts",
                columns: new[] { "CoinId", "UserId" });

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "Balance",
                value: 0.638677998082093m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "Balance",
                value: 5.03067968910936m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "Balance",
                value: 1.30036933035774m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "Balance",
                value: 7.40630335783803m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Balance",
                value: 5.69420660251402m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Balance",
                value: 0.979941887335434m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 1 },
                column: "Balance",
                value: 4.6803293454317m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 2 },
                column: "Balance",
                value: 3.36498406131294m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "Balance",
                value: 2.12379517414381m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 1 },
                column: "Balance",
                value: 3.89336104179163m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 2 },
                column: "Balance",
                value: 5.26427895452732m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 4, 3 },
                column: "Balance",
                value: 6.13521738009358m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 1 },
                column: "Balance",
                value: 8.03532059994319m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 2 },
                column: "Balance",
                value: 7.92766583811028m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 5, 3 },
                column: "Balance",
                value: 7.73757591783846m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 1 },
                column: "Balance",
                value: 8.70404304466428m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 2 },
                column: "Balance",
                value: 2.86074035556469m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 6, 3 },
                column: "Balance",
                value: 9.15817198907982m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 1 },
                column: "Balance",
                value: 6.24626380933528m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 2 },
                column: "Balance",
                value: 1.90365287555499m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 7, 3 },
                column: "Balance",
                value: 7.42028571321429m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 1 },
                column: "Balance",
                value: 6.42740847586957m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 2 },
                column: "Balance",
                value: 1.07485712354424m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 8, 3 },
                column: "Balance",
                value: 8.44497908297916m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 1 },
                column: "Balance",
                value: 0.695590064732306m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 2 },
                column: "Balance",
                value: 0.878933476156998m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 9, 3 },
                column: "Balance",
                value: 6.77169110441623m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 1 },
                column: "Balance",
                value: 0.0928854547096136m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 2 },
                column: "Balance",
                value: 3.80426236785248m);

            migrationBuilder.UpdateData(
                table: "CoinAccounts",
                keyColumns: new[] { "CoinId", "UserId" },
                keyValues: new object[] { 10, 3 },
                column: "Balance",
                value: 2.06933967778029m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "e57163b0-c55f-4ed7-a8dc-146734e3be5a", "31bb9c79e3b24accb58dbf1fd9ac3d9c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "99b46031-8e5e-4da8-922b-47f2dc2c7eb7", "a48ec60ec0aa4543a76bc3ca52242b05" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Token", "WalletAddress" },
                values: new object[] { "7af4471b-7ceb-4c79-8045-754577e4b37b", "221646ac97254666a548e2476f1c97a5" });

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
    }
}
