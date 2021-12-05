using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace yedihisse.DataAccess.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch.Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirmId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch.Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Company.Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company.Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Firm.Firm",
                columns: table => new
                {
                    FirmId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirmName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firm.Firm", x => x.FirmId);
                    table.ForeignKey(
                        name: "FK_Firm.Firm_Company.Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company.Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slaughterhouse.Slaughterhouse",
                columns: table => new
                {
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SlaughterhouseName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.Slaughterhouse", x => x.SlaughterhouseId);
                });

            migrationBuilder.CreateTable(
                name: "User.User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    PasswordHash = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User.User_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.User_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Address.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CanAllotment = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Animal.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.StatusType",
                columns: table => new
                {
                    StatusTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationStatusTypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.StatusType", x => x.StatusTypeId);
                    table.ForeignKey(
                        name: "FK_Application.StatusType_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.StatusType_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_Branch.Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch.Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car.MissionType",
                columns: table => new
                {
                    CarMissionTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarMissionTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.MissionType", x => x.CarMissionTypeId);
                    table.ForeignKey(
                        name: "FK_Car.MissionType_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.MissionType_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Car.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Company.Manager_Company.Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company.Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company.Manager_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company.Manager_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Firm.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FirmId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firm.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_Firm.Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firm.Firm",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Killing.GroupType",
                columns: table => new
                {
                    GroupTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KillingGroupTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killing.GroupType", x => x.GroupTypeId);
                    table.ForeignKey(
                        name: "FK_Killing.GroupType_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.GroupType_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment.Option",
                columns: table => new
                {
                    PaymentOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentOptionName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment.Option", x => x.PaymentOptionId);
                    table.ForeignKey(
                        name: "FK_Payment.Option_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Option_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment.Type",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentTypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment.Type", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_Payment.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumberTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slaughterhouse.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_Slaughterhouse.Slaughterhouse_Slaugh~",
                        column: x => x.SlaughterhouseId,
                        principalTable: "Slaughterhouse.Slaughterhouse",
                        principalColumn: "SlaughterhouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slaughterhouse.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SlaughterhouseTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_User.Type_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.Type_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address.Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    District = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Parish = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ApartmentName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ApartmentNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ApartmentBlokName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FloorNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FlatNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AddressDetail = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    AddressDirection = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    AddressTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address.Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address.Address_Address.Type_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "Address.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address.Address_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address.Address_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Killing.Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KillingGroupName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    KillingGroupTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killing.Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Killing.Group_Killing.GroupType_KillingGroupTypeId",
                        column: x => x.KillingGroupTypeId,
                        principalTable: "Killing.GroupType",
                        principalColumn: "GroupTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.Group_Slaughterhouse.Slaughterhouse_SlaughterhouseId",
                        column: x => x.SlaughterhouseId,
                        principalTable: "Slaughterhouse.Slaughterhouse",
                        principalColumn: "SlaughterhouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.Group_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.Group_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber.PhoneNumber",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    PhoneNumberTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber.PhoneNumber", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.PhoneNumber_PhoneNumber.Type_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumber.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.PhoneNumber_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.PhoneNumber_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slaughterhouse.JoinType",
                columns: table => new
                {
                    JoinTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoldingCapacity = table.Column<int>(type: "integer", maxLength: 2500, nullable: false, defaultValue: 0),
                    KillingCapacity = table.Column<int>(type: "integer", maxLength: 250, nullable: false, defaultValue: 0),
                    ShreddingCapacity = table.Column<int>(type: "integer", maxLength: 250, nullable: false, defaultValue: 0),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    SlaughterhouseTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.JoinType", x => x.JoinTypeId);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinType_Slaughterhouse.Slaughterhouse_Slaug~",
                        column: x => x.SlaughterhouseId,
                        principalTable: "Slaughterhouse.Slaughterhouse",
                        principalColumn: "SlaughterhouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinType_Slaughterhouse.Type_SlaughterhouseT~",
                        column: x => x.SlaughterhouseTypeId,
                        principalTable: "Slaughterhouse.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinType_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinType_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User.JoinType",
                columns: table => new
                {
                    JoinTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.JoinType", x => x.JoinTypeId);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.Type_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "User.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car.Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CarNumberPlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CattleCapacity = table.Column<int>(type: "integer", maxLength: 1000, nullable: true),
                    OvineCapacity = table.Column<int>(type: "integer", maxLength: 1000, nullable: true),
                    IsAwning = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CarTypeId = table.Column<int>(type: "integer", nullable: false),
                    CarMissionTypeId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car.Car_Car.MissionType_CarMissionTypeId",
                        column: x => x.CarMissionTypeId,
                        principalTable: "Car.MissionType",
                        principalColumn: "CarMissionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car.Car_Car.Type_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "Car.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Car_PhoneNumber.PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber.PhoneNumber",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Car_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Car_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal.Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<float>(type: "real", precision: 2, scale: 2, nullable: false, defaultValue: 0f),
                    Kilo = table.Column<float>(type: "real", precision: 4, scale: 4, nullable: false, defaultValue: 0f),
                    Code = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Cost = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    Gain = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    EarCode = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    BaitCode = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal.Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal.Animal_Animal.Type_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "Animal.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal.Animal_Car.Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car.Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal.Animal_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal.Animal_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Car.Manager_Car.Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car.Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Manager_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Manager_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allotment.Allotment",
                columns: table => new
                {
                    AllotmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AllotmentPrePay = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    AllotmentPayment = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    AllotmentKillingPrice = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allotment.Allotment", x => x.AllotmentId);
                    table.ForeignKey(
                        name: "FK_Allotment.Allotment_Animal.Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal.Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allotment.Allotment_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allotment.Allotment_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Killing.JoinAnimal",
                columns: table => new
                {
                    JoinAnimalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KillingNumber = table.Column<int>(type: "integer", maxLength: 1000, nullable: false),
                    KillingComplate = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    KillingGroupId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killing.JoinAnimal", x => x.JoinAnimalId);
                    table.ForeignKey(
                        name: "FK_Killing.JoinAnimal_Animal.Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal.Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.JoinAnimal_Killing.Group_KillingGroupId",
                        column: x => x.KillingGroupId,
                        principalTable: "Killing.Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.JoinAnimal_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Killing.JoinAnimal_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllotmentRate = table.Column<byte>(type: "smallint", maxLength: 7, nullable: false, defaultValue: (byte)1),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    RemainingPrice = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    RemainingPrePay = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    RemainingKillingPrice = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    AllotmentId = table.Column<int>(type: "integer", nullable: true),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application.Application_Allotment.Allotment_AllotmentId",
                        column: x => x.AllotmentId,
                        principalTable: "Allotment.Allotment",
                        principalColumn: "AllotmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Application_Animal.Type_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "Animal.Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_Branch.Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch.Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationStatusTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Status", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Application.Status_Application.Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application.Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Status_Application.StatusType_ApplicationStatus~",
                        column: x => x.ApplicationStatusTypeId,
                        principalTable: "Application.StatusType",
                        principalColumn: "StatusTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Status_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Status_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment.Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentMade = table.Column<string>(type: "text", precision: 4, scale: 4, nullable: false, defaultValue: "0"),
                    ReceiptNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    PaymentOptionId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment.Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment.Payment_Application.Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application.Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Payment_Payment.Option_PaymentOptionId",
                        column: x => x.PaymentOptionId,
                        principalTable: "Payment.Option",
                        principalColumn: "PaymentOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Payment_Payment.Type_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "Payment.Type",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Payment_User.User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment.Payment_User.User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address.Address_AddressTypeId",
                table: "Address.Address",
                column: "AddressTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address.Address_CreatedByUserId",
                table: "Address.Address",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Address_ModifiedByUserId",
                table: "Address.Address",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Type_CreatedByUserId",
                table: "Address.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Type_ModifiedByUserId",
                table: "Address.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_AnimalId",
                table: "Allotment.Allotment",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_CreatedByUserId",
                table: "Allotment.Allotment",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_ModifiedByUserId",
                table: "Allotment.Allotment",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_AnimalTypeId",
                table: "Animal.Animal",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_CarId",
                table: "Animal.Animal",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_CreatedByUserId",
                table: "Animal.Animal",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_ModifiedByUserId",
                table: "Animal.Animal",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Type_CreatedByUserId",
                table: "Animal.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Type_ModifiedByUserId",
                table: "Animal.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_AllotmentId",
                table: "Application.Application",
                column: "AllotmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_AnimalTypeId",
                table: "Application.Application",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_BranchId",
                table: "Application.Application",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_CreatedByUserId",
                table: "Application.Application",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_ModifiedByUserId",
                table: "Application.Application",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_UserId",
                table: "Application.Application",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_ApplicationId",
                table: "Application.Status",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_ApplicationStatusTypeId",
                table: "Application.Status",
                column: "ApplicationStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_CreatedByUserId",
                table: "Application.Status",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_ModifiedByUserId",
                table: "Application.Status",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.StatusType_CreatedByUserId",
                table: "Application.StatusType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.StatusType_ModifiedByUserId",
                table: "Application.StatusType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_AddressId",
                table: "Branch.Branch",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_CreatedByUserId",
                table: "Branch.Branch",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_FirmId",
                table: "Branch.Branch",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_ModifiedByUserId",
                table: "Branch.Branch",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_PhoneNumberId",
                table: "Branch.Branch",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_BranchId",
                table: "Branch.Manager",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_CreatedByUserId",
                table: "Branch.Manager",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_ModifiedByUserId",
                table: "Branch.Manager",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_UserId",
                table: "Branch.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_CarMissionTypeId",
                table: "Car.Car",
                column: "CarMissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_CarTypeId",
                table: "Car.Car",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_CreatedByUserId",
                table: "Car.Car",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_ModifiedByUserId",
                table: "Car.Car",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_PhoneNumberId",
                table: "Car.Car",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Manager_CarId",
                table: "Car.Manager",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Manager_CreatedByUserId",
                table: "Car.Manager",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Manager_ModifiedByUserId",
                table: "Car.Manager",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Manager_UserId",
                table: "Car.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.MissionType_CreatedByUserId",
                table: "Car.MissionType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.MissionType_ModifiedByUserId",
                table: "Car.MissionType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Type_CreatedByUserId",
                table: "Car.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Type_ModifiedByUserId",
                table: "Car.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_AddressId",
                table: "Company.Company",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_CreatedByUserId",
                table: "Company.Company",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_ModifiedByUserId",
                table: "Company.Company",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_PhoneNumberId",
                table: "Company.Company",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_CompanyId",
                table: "Company.Manager",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_CreatedByUserId",
                table: "Company.Manager",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_ModifiedByUserId",
                table: "Company.Manager",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_UserId",
                table: "Company.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_AddressId",
                table: "Firm.Firm",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_CompanyId",
                table: "Firm.Firm",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_CreatedByUserId",
                table: "Firm.Firm",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_ModifiedByUserId",
                table: "Firm.Firm",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_PhoneNumberId",
                table: "Firm.Firm",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_CreatedByUserId",
                table: "Firm.Manager",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_FirmId",
                table: "Firm.Manager",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_ModifiedByUserId",
                table: "Firm.Manager",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_UserId",
                table: "Firm.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.Group_CreatedByUserId",
                table: "Killing.Group",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.Group_KillingGroupTypeId",
                table: "Killing.Group",
                column: "KillingGroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.Group_ModifiedByUserId",
                table: "Killing.Group",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.Group_SlaughterhouseId",
                table: "Killing.Group",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.GroupType_CreatedByUserId",
                table: "Killing.GroupType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.GroupType_ModifiedByUserId",
                table: "Killing.GroupType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.JoinAnimal_AnimalId",
                table: "Killing.JoinAnimal",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Killing.JoinAnimal_CreatedByUserId",
                table: "Killing.JoinAnimal",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.JoinAnimal_KillingGroupId",
                table: "Killing.JoinAnimal",
                column: "KillingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Killing.JoinAnimal_ModifiedByUserId",
                table: "Killing.JoinAnimal",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Option_CreatedByUserId",
                table: "Payment.Option",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Option_ModifiedByUserId",
                table: "Payment.Option",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Payment_ApplicationId",
                table: "Payment.Payment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Payment_CreatedByUserId",
                table: "Payment.Payment",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Payment_ModifiedByUserId",
                table: "Payment.Payment",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Payment_PaymentOptionId",
                table: "Payment.Payment",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Payment_PaymentTypeId",
                table: "Payment.Payment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Type_CreatedByUserId",
                table: "Payment.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment.Type_ModifiedByUserId",
                table: "Payment.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_CreatedByUserId",
                table: "PhoneNumber.PhoneNumber",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_ModifiedByUserId",
                table: "PhoneNumber.PhoneNumber",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_PhoneNumberTypeId",
                table: "PhoneNumber.PhoneNumber",
                column: "PhoneNumberTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.Type_CreatedByUserId",
                table: "PhoneNumber.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.Type_ModifiedByUserId",
                table: "PhoneNumber.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_CreatedByUserId",
                table: "Slaughterhouse.JoinType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_ModifiedByUserId",
                table: "Slaughterhouse.JoinType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_SlaughterhouseId",
                table: "Slaughterhouse.JoinType",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_SlaughterhouseTypeId",
                table: "Slaughterhouse.JoinType",
                column: "SlaughterhouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_CreatedByUserId",
                table: "Slaughterhouse.Manager",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_ModifiedByUserId",
                table: "Slaughterhouse.Manager",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_SlaughterhouseId",
                table: "Slaughterhouse.Manager",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_UserId",
                table: "Slaughterhouse.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_AddressId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_CreatedByUserId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_ModifiedByUserId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_PhoneNumberId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Type_CreatedByUserId",
                table: "Slaughterhouse.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Type_ModifiedByUserId",
                table: "Slaughterhouse.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_CreatedByUserId",
                table: "User.JoinType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_ModifiedByUserId",
                table: "User.JoinType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserId",
                table: "User.JoinType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserTypeId",
                table: "User.JoinType",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User.Type_CreatedByUserId",
                table: "User.Type",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.Type_ModifiedByUserId",
                table: "User.Type",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_AddressId",
                table: "User.User",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.User_CreatedByUserId",
                table: "User.User",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_EmailAddress",
                table: "User.User",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.User_ModifiedByUserId",
                table: "User.User",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_PhoneNumberId",
                table: "User.User",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_UserPhoneNumber",
                table: "User.User",
                column: "UserPhoneNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_Address.Address_AddressId",
                table: "Branch.Branch",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_Firm.Firm_FirmId",
                table: "Branch.Branch",
                column: "FirmId",
                principalTable: "Firm.Firm",
                principalColumn: "FirmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Branch.Branch",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_User.User_CreatedByUserId",
                table: "Branch.Branch",
                column: "CreatedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_User.User_ModifiedByUserId",
                table: "Branch.Branch",
                column: "ModifiedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_Address.Address_AddressId",
                table: "Company.Company",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Company.Company",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_User.User_CreatedByUserId",
                table: "Company.Company",
                column: "CreatedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_User.User_ModifiedByUserId",
                table: "Company.Company",
                column: "ModifiedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_Address.Address_AddressId",
                table: "Firm.Firm",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Firm.Firm",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_User.User_CreatedByUserId",
                table: "Firm.Firm",
                column: "CreatedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_User.User_ModifiedByUserId",
                table: "Firm.Firm",
                column: "ModifiedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_Address.Address_AddressId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_PhoneNumber.PhoneNumber_Phone~",
                table: "Slaughterhouse.Slaughterhouse",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_User.User_CreatedByUserId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "CreatedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_User.User_ModifiedByUserId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "ModifiedByUserId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User.User_Address.Address_AddressId",
                table: "User.User",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User.User_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "User.User",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_Address.Type_AddressTypeId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_User.User_CreatedByUserId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_User.User_ModifiedByUserId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.PhoneNumber_User.User_CreatedByUserId",
                table: "PhoneNumber.PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.PhoneNumber_User.User_ModifiedByUserId",
                table: "PhoneNumber.PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.Type_User.User_CreatedByUserId",
                table: "PhoneNumber.Type");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.Type_User.User_ModifiedByUserId",
                table: "PhoneNumber.Type");

            migrationBuilder.DropTable(
                name: "Application.Status");

            migrationBuilder.DropTable(
                name: "Branch.Manager");

            migrationBuilder.DropTable(
                name: "Car.Manager");

            migrationBuilder.DropTable(
                name: "Company.Manager");

            migrationBuilder.DropTable(
                name: "Firm.Manager");

            migrationBuilder.DropTable(
                name: "Killing.JoinAnimal");

            migrationBuilder.DropTable(
                name: "Payment.Payment");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.JoinType");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Manager");

            migrationBuilder.DropTable(
                name: "User.JoinType");

            migrationBuilder.DropTable(
                name: "Application.StatusType");

            migrationBuilder.DropTable(
                name: "Killing.Group");

            migrationBuilder.DropTable(
                name: "Application.Application");

            migrationBuilder.DropTable(
                name: "Payment.Option");

            migrationBuilder.DropTable(
                name: "Payment.Type");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Type");

            migrationBuilder.DropTable(
                name: "User.Type");

            migrationBuilder.DropTable(
                name: "Killing.GroupType");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Slaughterhouse");

            migrationBuilder.DropTable(
                name: "Allotment.Allotment");

            migrationBuilder.DropTable(
                name: "Branch.Branch");

            migrationBuilder.DropTable(
                name: "Animal.Animal");

            migrationBuilder.DropTable(
                name: "Firm.Firm");

            migrationBuilder.DropTable(
                name: "Animal.Type");

            migrationBuilder.DropTable(
                name: "Car.Car");

            migrationBuilder.DropTable(
                name: "Company.Company");

            migrationBuilder.DropTable(
                name: "Car.MissionType");

            migrationBuilder.DropTable(
                name: "Car.Type");

            migrationBuilder.DropTable(
                name: "Address.Type");

            migrationBuilder.DropTable(
                name: "User.User");

            migrationBuilder.DropTable(
                name: "Address.Address");

            migrationBuilder.DropTable(
                name: "PhoneNumber.PhoneNumber");

            migrationBuilder.DropTable(
                name: "PhoneNumber.Type");
        }
    }
}
