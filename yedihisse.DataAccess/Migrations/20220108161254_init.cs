using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yedihisse.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 53, 998, DateTimeKind.Local).AddTicks(3282), new DateTime(2022, 1, 8, 19, 12, 53, 998, DateTimeKind.Local).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 53, 998, DateTimeKind.Local).AddTicks(5333), new DateTime(2022, 1, 8, 19, 12, 53, 998, DateTimeKind.Local).AddTicks(5334) });

            migrationBuilder.UpdateData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 54, 100, DateTimeKind.Local).AddTicks(2254), new DateTime(2022, 1, 8, 19, 12, 54, 100, DateTimeKind.Local).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 54, 100, DateTimeKind.Local).AddTicks(2657), new DateTime(2022, 1, 8, 19, 12, 54, 100, DateTimeKind.Local).AddTicks(2658) });

            migrationBuilder.UpdateData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 54, 54, DateTimeKind.Local).AddTicks(3023), new DateTime(2022, 1, 8, 19, 12, 54, 54, DateTimeKind.Local).AddTicks(3308), "2y5r4AoNCi3XT3tYW+2vc4Q3yM+wDp6IkFAErKTE+Hcw+l+h" });

            migrationBuilder.UpdateData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 1, 8, 19, 12, 54, 90, DateTimeKind.Local).AddTicks(7744), new DateTime(2022, 1, 8, 19, 12, 54, 90, DateTimeKind.Local).AddTicks(7771), "9ywTe/OLkaRVMTxGjRKyGnTfZjp+rQwVMRE2ezz6+TsYXZRl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(2830), new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3947), new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3110), new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3434), new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3435) });

            migrationBuilder.UpdateData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 867, DateTimeKind.Local).AddTicks(3675), new DateTime(2022, 1, 8, 18, 15, 0, 867, DateTimeKind.Local).AddTicks(3953), "B69mYHLfWTcsTEQSRZkGiUEMWIOPRTEJkn80B5jZ5E9laCTL" });

            migrationBuilder.UpdateData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 1, 8, 18, 15, 0, 902, DateTimeKind.Local).AddTicks(865), new DateTime(2022, 1, 8, 18, 15, 0, 902, DateTimeKind.Local).AddTicks(892), "XFxL46s2cPMG8QMGuVwtp/VFgzaJYOFd03kWXiJgwNFHXPU5" });
        }
    }
}
