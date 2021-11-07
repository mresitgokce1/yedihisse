using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace yedihisse.DataAccess.Migrations
{
    public partial class InitialCreate2 : Migration
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
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    FirmId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.Slaughterhouse", x => x.SlaughterhouseId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier.Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    SupplierTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier.Supplier", x => x.SupplierId);
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
                    EmailAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User.User_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.User_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Address.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CanAllotment = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Animal.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.StatusType", x => x.StatusTypeId);
                    table.ForeignKey(
                        name: "FK_Application.StatusType_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.StatusType_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Branch.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Car.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Company.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Firm.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firm.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipping.Shipping",
                columns: table => new
                {
                    ShippingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping.Shipping", x => x.ShippingId);
                    table.ForeignKey(
                        name: "FK_Shipping.Shipping_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipping.Shipping_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Slaughterhouse.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Supplier.Manager_Supplier.Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier.Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier.Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Supplier.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_User.Type_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.Type_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    Parish = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ApartmentName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ApartmentNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ApartmentBlokName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FloorNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FlatNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AddressDetail = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    AddressDirection = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    AddressTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Address.Address_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address.Address_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Animal.Animal_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal.Animal_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_PhoneNumber.PhoneNumber_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber.PhoneNumber_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipping.Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ShippingId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping.Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Shipping.Manager_Shipping.Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping.Shipping",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipping.Manager_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipping.Manager_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipping.Manager_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    HoldingCapacity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    KillingCapacity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ShreddingCapacity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    SlaughterhouseTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Slaughterhouse.JoinType_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinType_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_User.JoinType_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User.JoinType_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    PrePay = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    PrePayStatus = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PrePayReceiptNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(4,4)", precision: 4, scale: 4, nullable: false, defaultValue: 0m),
                    PriceStatus = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PriceReceiptNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    ShippingId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Allotment.Allotment_Shipping.Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping.Shipping",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allotment.Allotment_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allotment.Allotment_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slaughterhouse.JoinAnimal",
                columns: table => new
                {
                    JoinAnimalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KillingNumber = table.Column<int>(type: "integer", nullable: false),
                    KillingPrice = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    KillingComplate = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SlaughterhouseId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slaughterhouse.JoinAnimal", x => x.JoinAnimalId);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinAnimal_Animal.Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal.Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinAnimal_Slaughterhouse.Slaughterhouse_Sla~",
                        column: x => x.SlaughterhouseId,
                        principalTable: "Slaughterhouse.Slaughterhouse",
                        principalColumn: "SlaughterhouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinAnimal_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slaughterhouse.JoinAnimal_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    CarName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CarNumberPlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CarTypeId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "integer", nullable: false),
                    ShippingId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car.Car", x => x.CarId);
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
                        name: "FK_Car.Car_Shipping.Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping.Shipping",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Car_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car.Car_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    AllotmentRate = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    AllotmentId = table.Column<int>(type: "integer", nullable: false),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application.Application_Allotment.Allotment_AllotmentId",
                        column: x => x.AllotmentId,
                        principalTable: "Allotment.Allotment",
                        principalColumn: "AllotmentId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Application.Application_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_User.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Application_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                    UserCreatedByIdId = table.Column<int>(type: "integer", nullable: false),
                    UserModifiedByIdId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    ModifiedById = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_Application.Status_User.User_UserCreatedByIdId",
                        column: x => x.UserCreatedByIdId,
                        principalTable: "User.User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Status_User.User_UserModifiedByIdId",
                        column: x => x.UserModifiedByIdId,
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
                name: "IX_Address.Address_UserCreatedByIdId",
                table: "Address.Address",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Address_UserModifiedByIdId",
                table: "Address.Address",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Type_UserCreatedByIdId",
                table: "Address.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Address.Type_UserModifiedByIdId",
                table: "Address.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_AnimalId",
                table: "Allotment.Allotment",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_ShippingId",
                table: "Allotment.Allotment",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_UserCreatedByIdId",
                table: "Allotment.Allotment",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Allotment.Allotment_UserModifiedByIdId",
                table: "Allotment.Allotment",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_AnimalTypeId",
                table: "Animal.Animal",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_UserCreatedByIdId",
                table: "Animal.Animal",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Animal_UserModifiedByIdId",
                table: "Animal.Animal",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Type_UserCreatedByIdId",
                table: "Animal.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal.Type_UserModifiedByIdId",
                table: "Animal.Type",
                column: "UserModifiedByIdId");

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
                name: "IX_Application.Application_UserCreatedByIdId",
                table: "Application.Application",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_UserId",
                table: "Application.Application",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Application_UserModifiedByIdId",
                table: "Application.Application",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_ApplicationId",
                table: "Application.Status",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_ApplicationStatusTypeId",
                table: "Application.Status",
                column: "ApplicationStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_UserCreatedByIdId",
                table: "Application.Status",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Status_UserModifiedByIdId",
                table: "Application.Status",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.StatusType_UserCreatedByIdId",
                table: "Application.StatusType",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.StatusType_UserModifiedByIdId",
                table: "Application.StatusType",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_AddressId",
                table: "Branch.Branch",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_FirmId",
                table: "Branch.Branch",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_PhoneNumberId",
                table: "Branch.Branch",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_UserCreatedByIdId",
                table: "Branch.Branch",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Branch_UserModifiedByIdId",
                table: "Branch.Branch",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_BranchId",
                table: "Branch.Manager",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_UserCreatedByIdId",
                table: "Branch.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_UserId",
                table: "Branch.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch.Manager_UserModifiedByIdId",
                table: "Branch.Manager",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_CarTypeId",
                table: "Car.Car",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_PhoneNumberId",
                table: "Car.Car",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_ShippingId",
                table: "Car.Car",
                column: "ShippingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_UserCreatedByIdId",
                table: "Car.Car",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Car_UserModifiedByIdId",
                table: "Car.Car",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Type_UserCreatedByIdId",
                table: "Car.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Car.Type_UserModifiedByIdId",
                table: "Car.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_AddressId",
                table: "Company.Company",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_PhoneNumberId",
                table: "Company.Company",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_UserCreatedByIdId",
                table: "Company.Company",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Company_UserModifiedByIdId",
                table: "Company.Company",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_CompanyId",
                table: "Company.Manager",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_UserCreatedByIdId",
                table: "Company.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_UserId",
                table: "Company.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company.Manager_UserModifiedByIdId",
                table: "Company.Manager",
                column: "UserModifiedByIdId");

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
                name: "IX_Firm.Firm_PhoneNumberId",
                table: "Firm.Firm",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_UserCreatedByIdId",
                table: "Firm.Firm",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Firm_UserModifiedByIdId",
                table: "Firm.Firm",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_FirmId",
                table: "Firm.Manager",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_UserCreatedByIdId",
                table: "Firm.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_UserId",
                table: "Firm.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firm.Manager_UserModifiedByIdId",
                table: "Firm.Manager",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_PhoneNumberTypeId",
                table: "PhoneNumber.PhoneNumber",
                column: "PhoneNumberTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_UserCreatedByIdId",
                table: "PhoneNumber.PhoneNumber",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.PhoneNumber_UserModifiedByIdId",
                table: "PhoneNumber.PhoneNumber",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.Type_UserCreatedByIdId",
                table: "PhoneNumber.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber.Type_UserModifiedByIdId",
                table: "PhoneNumber.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Manager_ShippingId",
                table: "Shipping.Manager",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Manager_UserCreatedByIdId",
                table: "Shipping.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Manager_UserId",
                table: "Shipping.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Manager_UserModifiedByIdId",
                table: "Shipping.Manager",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Shipping_UserCreatedByIdId",
                table: "Shipping.Shipping",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping.Shipping_UserModifiedByIdId",
                table: "Shipping.Shipping",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinAnimal_AnimalId",
                table: "Slaughterhouse.JoinAnimal",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinAnimal_KillingNumber",
                table: "Slaughterhouse.JoinAnimal",
                column: "KillingNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinAnimal_SlaughterhouseId",
                table: "Slaughterhouse.JoinAnimal",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinAnimal_UserCreatedByIdId",
                table: "Slaughterhouse.JoinAnimal",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinAnimal_UserModifiedByIdId",
                table: "Slaughterhouse.JoinAnimal",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_SlaughterhouseId",
                table: "Slaughterhouse.JoinType",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_SlaughterhouseTypeId",
                table: "Slaughterhouse.JoinType",
                column: "SlaughterhouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_UserCreatedByIdId",
                table: "Slaughterhouse.JoinType",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.JoinType_UserModifiedByIdId",
                table: "Slaughterhouse.JoinType",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_SlaughterhouseId",
                table: "Slaughterhouse.Manager",
                column: "SlaughterhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_UserCreatedByIdId",
                table: "Slaughterhouse.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_UserId",
                table: "Slaughterhouse.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Manager_UserModifiedByIdId",
                table: "Slaughterhouse.Manager",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_AddressId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_PhoneNumberId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_UserCreatedByIdId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Slaughterhouse_UserModifiedByIdId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Type_UserCreatedByIdId",
                table: "Slaughterhouse.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Slaughterhouse.Type_UserModifiedByIdId",
                table: "Slaughterhouse.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Manager_SupplierId",
                table: "Supplier.Manager",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Manager_UserCreatedByIdId",
                table: "Supplier.Manager",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Manager_UserId",
                table: "Supplier.Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Manager_UserModifiedByIdId",
                table: "Supplier.Manager",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Supplier_AddressId",
                table: "Supplier.Supplier",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Supplier_PhoneNumberId",
                table: "Supplier.Supplier",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Supplier_SupplierTypeId",
                table: "Supplier.Supplier",
                column: "SupplierTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Supplier_UserCreatedByIdId",
                table: "Supplier.Supplier",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Supplier_UserModifiedByIdId",
                table: "Supplier.Supplier",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Type_UserCreatedByIdId",
                table: "Supplier.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier.Type_UserModifiedByIdId",
                table: "Supplier.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserCreatedByIdId",
                table: "User.JoinType",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserId",
                table: "User.JoinType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserModifiedByIdId",
                table: "User.JoinType",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.JoinType_UserTypeId",
                table: "User.JoinType",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User.Type_UserCreatedByIdId",
                table: "User.Type",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.Type_UserModifiedByIdId",
                table: "User.Type",
                column: "UserModifiedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_AddressId",
                table: "User.User",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.User_EmailAddress",
                table: "User.User",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.User_PhoneNumberId",
                table: "User.User",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_UserCreatedByIdId",
                table: "User.User",
                column: "UserCreatedByIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User.User_UserModifiedByIdId",
                table: "User.User",
                column: "UserModifiedByIdId");

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
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_User.User_UserCreatedByIdId",
                table: "Branch.Branch",
                column: "UserCreatedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch.Branch_User.User_UserModifiedByIdId",
                table: "Branch.Branch",
                column: "UserModifiedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_Address.Address_AddressId",
                table: "Company.Company",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Company.Company",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_User.User_UserCreatedByIdId",
                table: "Company.Company",
                column: "UserCreatedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company.Company_User.User_UserModifiedByIdId",
                table: "Company.Company",
                column: "UserModifiedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_Address.Address_AddressId",
                table: "Firm.Firm",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Firm.Firm",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_User.User_UserCreatedByIdId",
                table: "Firm.Firm",
                column: "UserCreatedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm.Firm_User.User_UserModifiedByIdId",
                table: "Firm.Firm",
                column: "UserModifiedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_Address.Address_AddressId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_PhoneNumber.PhoneNumber_Phone~",
                table: "Slaughterhouse.Slaughterhouse",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_User.User_UserCreatedByIdId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "UserCreatedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slaughterhouse.Slaughterhouse_User.User_UserModifiedByIdId",
                table: "Slaughterhouse.Slaughterhouse",
                column: "UserModifiedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier.Supplier_Address.Address_AddressId",
                table: "Supplier.Supplier",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier.Supplier_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "Supplier.Supplier",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier.Supplier_Supplier.Type_SupplierTypeId",
                table: "Supplier.Supplier",
                column: "SupplierTypeId",
                principalTable: "Supplier.Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier.Supplier_User.User_UserCreatedByIdId",
                table: "Supplier.Supplier",
                column: "UserCreatedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier.Supplier_User.User_UserModifiedByIdId",
                table: "Supplier.Supplier",
                column: "UserModifiedByIdId",
                principalTable: "User.User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User.User_Address.Address_AddressId",
                table: "User.User",
                column: "AddressId",
                principalTable: "Address.Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User.User_PhoneNumber.PhoneNumber_PhoneNumberId",
                table: "User.User",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber.PhoneNumber",
                principalColumn: "PhoneNumberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_Address.Type_AddressTypeId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_User.User_UserCreatedByIdId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address.Address_User.User_UserModifiedByIdId",
                table: "Address.Address");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.PhoneNumber_User.User_UserCreatedByIdId",
                table: "PhoneNumber.PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.PhoneNumber_User.User_UserModifiedByIdId",
                table: "PhoneNumber.PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.Type_User.User_UserCreatedByIdId",
                table: "PhoneNumber.Type");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber.Type_User.User_UserModifiedByIdId",
                table: "PhoneNumber.Type");

            migrationBuilder.DropTable(
                name: "Application.Status");

            migrationBuilder.DropTable(
                name: "Branch.Manager");

            migrationBuilder.DropTable(
                name: "Car.Car");

            migrationBuilder.DropTable(
                name: "Company.Manager");

            migrationBuilder.DropTable(
                name: "Firm.Manager");

            migrationBuilder.DropTable(
                name: "Shipping.Manager");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.JoinAnimal");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.JoinType");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Manager");

            migrationBuilder.DropTable(
                name: "Supplier.Manager");

            migrationBuilder.DropTable(
                name: "User.JoinType");

            migrationBuilder.DropTable(
                name: "Application.Application");

            migrationBuilder.DropTable(
                name: "Application.StatusType");

            migrationBuilder.DropTable(
                name: "Car.Type");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Type");

            migrationBuilder.DropTable(
                name: "Slaughterhouse.Slaughterhouse");

            migrationBuilder.DropTable(
                name: "Supplier.Supplier");

            migrationBuilder.DropTable(
                name: "User.Type");

            migrationBuilder.DropTable(
                name: "Allotment.Allotment");

            migrationBuilder.DropTable(
                name: "Branch.Branch");

            migrationBuilder.DropTable(
                name: "Supplier.Type");

            migrationBuilder.DropTable(
                name: "Animal.Animal");

            migrationBuilder.DropTable(
                name: "Shipping.Shipping");

            migrationBuilder.DropTable(
                name: "Firm.Firm");

            migrationBuilder.DropTable(
                name: "Animal.Type");

            migrationBuilder.DropTable(
                name: "Company.Company");

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
