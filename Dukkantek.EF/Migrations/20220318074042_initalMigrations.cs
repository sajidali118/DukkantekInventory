using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dukkantek.EF.Migrations
{
    public partial class initalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditDateTimeUtc = table.Column<DateTime>(nullable: false),
                    AuditType = table.Column<string>(nullable: true),
                    AuditUser = table.Column<long>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    KeyValues = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true),
                    ChangedColumns = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CategoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSells",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSells_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name", "ShortName" },
                values: new object[] { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Electronic Devices", "Electronic Devices" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name", "ShortName" },
                values: new object[] { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Health & Beauty", "Health & Beauty" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name", "ShortName" },
                values: new object[] { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Sports & Outdoor", "Sports & Outdoor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name", "Status", "Weight" },
                values: new object[,]
                {
                    { 1L, "xxxxxxxxxxxxxxx", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900", false, null, null, "IPhone 13 Pro", 2, 90 },
                    { 2L, "xxxxxxxxxxxxxxx123", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900", false, null, null, "IPhone 12 Pro", 2, 85 },
                    { 3L, "xxxxxxxxxxxxxxx234", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900", false, null, null, "IPhone 13 Pro MAX", 1, 95 },
                    { 4L, "xxxxxxxxxxxxxxx3333", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900", false, null, null, "IPhone 12 Pro MAX", 3, 95 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSells_ProductId",
                table: "ProductSells",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ProductSells");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
