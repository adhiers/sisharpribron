using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisharpriborn.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cobaMigrasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    VIN = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ModelType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FuelType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Car__68A0342E76DD1CAA", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IdCardNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D80FC9D307", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    DealerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DealerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DealerAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dealer__CA2F8EB2DFA14A30", x => x.DealerId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NominalKredit = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Bunga = table.Column<double>(type: "float", nullable: false),
                    MonthlyPayment = table.Column<double>(type: "float", nullable: false),
                    StatusCredit = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Credit__ED5ED0BB4B8EF0CC", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK__Credit__Customer__740F363E",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "DealerCarList",
                columns: table => new
                {
                    DealerCarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DealerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    DealerCarPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DealerCa__7DD0B58628B0B455", x => x.DealerCarId);
                    table.ForeignKey(
                        name: "FK__DealerCar__CarId__63D8CE75",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK__DealerCar__Deale__64CCF2AE",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "DealerId");
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SalesPersonId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SalesName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DealerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SalesPer__7A591C38E80E52F0", x => x.SalesPersonId);
                    table.ForeignKey(
                        name: "FK__SalesPers__Deale__60FC61CA",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "DealerId");
                });

            migrationBuilder.CreateTable(
                name: "LetterOfIntent",
                columns: table => new
                {
                    LOIId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NegoPrice = table.Column<double>(type: "float", nullable: false),
                    DealerCarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    BookingFee = table.Column<double>(type: "float", nullable: true),
                    PaymentMethod = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LetterOf__E21E1B4C6C1B14CA", x => x.LOIId);
                    table.ForeignKey(
                        name: "FK__LetterOfI__Deale__7132C993",
                        column: x => x.DealerCarId,
                        principalTable: "DealerCarList",
                        principalColumn: "DealerCarId");
                });

            migrationBuilder.CreateTable(
                name: "ConsultHistory",
                columns: table => new
                {
                    ConsultId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SalesPersonId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false),
                    ConsultDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ConsultH__28859B358E08874E", x => x.ConsultId);
                    table.ForeignKey(
                        name: "FK__ConsultHi__Custo__67A95F59",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__ConsultHi__Sales__689D8392",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonId");
                });

            migrationBuilder.CreateTable(
                name: "TestDriveNego",
                columns: table => new
                {
                    TDNId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ConsultId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DealerCarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DealerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SalesPersonId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    TDNDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestDriv__BC0D3AC587ECE0B2", x => x.TDNId);
                    table.ForeignKey(
                        name: "FK__TestDrive__Custo__6B79F03D",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__TestDrive__Deale__6C6E1476",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "DealerId");
                    table.ForeignKey(
                        name: "FK__TestDrive__Deale__6E565CE8",
                        column: x => x.DealerCarId,
                        principalTable: "DealerCarList",
                        principalColumn: "DealerCarId");
                    table.ForeignKey(
                        name: "FK__TestDrive__Sales__6D6238AF",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonId");
                });

            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    AgreementId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SalesPersonId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CreditId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DealerCarId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LOIId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MethodPayment = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    AgreementDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agreemen__0A3082C37867AFCC", x => x.AgreementId);
                    table.ForeignKey(
                        name: "FK__Agreement__Credi__79C80F94",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "CreditId");
                    table.ForeignKey(
                        name: "FK__Agreement__Custo__78D3EB5B",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__Agreement__Deale__7CA47C3F",
                        column: x => x.DealerCarId,
                        principalTable: "DealerCarList",
                        principalColumn: "DealerCarId");
                    table.ForeignKey(
                        name: "FK__Agreement__LOIId__7ABC33CD",
                        column: x => x.LOIId,
                        principalTable: "LetterOfIntent",
                        principalColumn: "LOIId");
                    table.ForeignKey(
                        name: "FK__Agreement__Sales__7BB05806",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonId");
                });

            migrationBuilder.CreateTable(
                name: "OtherBenefit",
                columns: table => new
                {
                    AgreementId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Benefit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OtherBen__0A3082C35A0C6F68", x => x.AgreementId);
                    table.ForeignKey(
                        name: "FK__OtherBene__Agree__025D5595",
                        column: x => x.AgreementId,
                        principalTable: "Agreement",
                        principalColumn: "AgreementId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    AgreementId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Nominal = table.Column<double>(type: "float", nullable: false),
                    PaymentLeft = table.Column<double>(type: "float", nullable: true),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentH__9B556A383622A597", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK__PaymentHi__Agree__7F80E8EA",
                        column: x => x.AgreementId,
                        principalTable: "Agreement",
                        principalColumn: "AgreementId");
                });

            migrationBuilder.CreateTable(
                name: "Warranty",
                columns: table => new
                {
                    WarrantyId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    AgreementId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    WarrantyPeriodDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warranty__2ED31813F37CC3C4", x => x.WarrantyId);
                    table.ForeignKey(
                        name: "FK__Warranty__Agreem__062DE679",
                        column: x => x.AgreementId,
                        principalTable: "Agreement",
                        principalColumn: "AgreementId");
                });

            migrationBuilder.CreateTable(
                name: "WarrantyClaim",
                columns: table => new
                {
                    ClaimId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    WarrantyId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ServiceCenter = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ServiceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ServiceCost = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warranty__EF2E139B66340F6A", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK__WarrantyC__Warra__090A5324",
                        column: x => x.WarrantyId,
                        principalTable: "Warranty",
                        principalColumn: "WarrantyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_CustomerId",
                table: "Agreement",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_DealerCarId",
                table: "Agreement",
                column: "DealerCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_SalesPersonId",
                table: "Agreement",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "UQ__Agreemen__E21E1B4DF45B50CA",
                table: "Agreement",
                column: "LOIId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Agreemen__ED5ED0BAA96CB6AE",
                table: "Agreement",
                column: "CreditId",
                unique: true,
                filter: "[CreditId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Car__C5DF234C36F8E37B",
                table: "Car",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultHistory_CustomerId",
                table: "ConsultHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultHistory_SalesPersonId",
                table: "ConsultHistory",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_CustomerId",
                table: "Credit",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerCarList_CarId",
                table: "DealerCarList",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerCarList_DealerId",
                table: "DealerCarList",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterOfIntent_DealerCarId",
                table: "LetterOfIntent",
                column: "DealerCarId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_AgreementId",
                table: "PaymentHistory",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_DealerId",
                table: "SalesPerson",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveNego_CustomerId",
                table: "TestDriveNego",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveNego_DealerCarId",
                table: "TestDriveNego",
                column: "DealerCarId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveNego_DealerId",
                table: "TestDriveNego",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveNego_SalesPersonId",
                table: "TestDriveNego",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "UQ__Warranty__0A3082C261A9FC44",
                table: "Warranty",
                column: "AgreementId",
                unique: true,
                filter: "[AgreementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaim_WarrantyId",
                table: "WarrantyClaim",
                column: "WarrantyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConsultHistory");

            migrationBuilder.DropTable(
                name: "OtherBenefit");

            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropTable(
                name: "TestDriveNego");

            migrationBuilder.DropTable(
                name: "WarrantyClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "LetterOfIntent");

            migrationBuilder.DropTable(
                name: "SalesPerson");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DealerCarList");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Dealer");
        }
    }
}
