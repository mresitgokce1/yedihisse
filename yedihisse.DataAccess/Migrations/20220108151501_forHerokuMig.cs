using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yedihisse.DataAccess.Migrations
{
    public partial class forHerokuMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Sex",
                table: "User.User",
                type: "character(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User.User",
                type: "character varying(48)",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BYTEA");

            migrationBuilder.InsertData(
                table: "User.User",
                columns: new[] { "UserId", "AddressId", "CreatedByUserId", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "ModifiedByUserId", "ModifiedDate", "PasswordHash", "PhoneNumberId", "Sex", "UserPhoneNumber" },
                values: new object[] { 1, null, 1, new DateTime(2022, 1, 8, 18, 15, 0, 867, DateTimeKind.Local).AddTicks(3675), "mrgokce@yandex.com", "Muhammed Reşit", true, "Gökce", 1, new DateTime(2022, 1, 8, 18, 15, 0, 867, DateTimeKind.Local).AddTicks(3953), "B69mYHLfWTcsTEQSRZkGiUEMWIOPRTEJkn80B5jZ5E9laCTL", null, 'E', "123" });

            migrationBuilder.InsertData(
                table: "User.Type",
                columns: new[] { "TypeId", "CreatedByUserId", "CreatedDate", "IsActive", "ModifiedByUserId", "ModifiedDate", "UserTypeName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3110), true, 1, new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3407), "Admin" },
                    { 2, 1, new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3434), true, 1, new DateTime(2022, 1, 8, 18, 15, 0, 910, DateTimeKind.Local).AddTicks(3435), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "User.User",
                columns: new[] { "UserId", "AddressId", "CreatedByUserId", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "ModifiedByUserId", "ModifiedDate", "PasswordHash", "PhoneNumberId", "Sex", "UserPhoneNumber" },
                values: new object[] { 2, null, 1, new DateTime(2022, 1, 8, 18, 15, 0, 902, DateTimeKind.Local).AddTicks(865), "agokce@yandex.com", "Ali", true, "Gökce", 1, new DateTime(2022, 1, 8, 18, 15, 0, 902, DateTimeKind.Local).AddTicks(892), "XFxL46s2cPMG8QMGuVwtp/VFgzaJYOFd03kWXiJgwNFHXPU5", null, 'E', "1234" });

            migrationBuilder.InsertData(
                table: "User.JoinType",
                columns: new[] { "JoinTypeId", "CreatedByUserId", "CreatedDate", "IsActive", "ModifiedByUserId", "ModifiedDate", "UserId", "UserTypeId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(2830), true, 1, new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3303), 1, 1 },
                    { 2, 1, new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3947), true, 1, new DateTime(2022, 1, 8, 18, 15, 0, 805, DateTimeKind.Local).AddTicks(3948), 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User.JoinType",
                keyColumn: "JoinTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User.Type",
                keyColumn: "TypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User.User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Sex",
                table: "User.User",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "User.User",
                type: "BYTEA",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(48)",
                oldMaxLength: 48);
        }
    }
}
