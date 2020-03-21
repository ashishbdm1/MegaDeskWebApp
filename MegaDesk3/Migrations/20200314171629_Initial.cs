using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RushOrderTypes",
                columns: table => new
                {
                    RushOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RushOrderName = table.Column<string>(nullable: true),
                    TierOnePrice = table.Column<decimal>(nullable: false),
                    TierTwoPrice = table.Column<decimal>(nullable: false),
                    TierThreePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushOrderTypes", x => x.RushOrderId);
                });

            migrationBuilder.CreateTable(
                name: "SurfaceMaterials",
                columns: table => new
                {
                    SurfaceMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceMaterials", x => x.SurfaceMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    DeskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Depth = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    NumberOfDrawers = table.Column<int>(nullable: false),
                    SurfaceMaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_Desks_SurfaceMaterials_SurfaceMaterialId",
                        column: x => x.SurfaceMaterialId,
                        principalTable: "SurfaceMaterials",
                        principalColumn: "SurfaceMaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuotes",
                columns: table => new
                {
                    DeskQuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: false),
                    RushOrderType = table.Column<int>(nullable: false),
                    DeskId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    QuotePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuotes", x => x.DeskQuoteId);
                    table.ForeignKey(
                        name: "FK_DeskQuotes_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuotes_DeskId",
                table: "DeskQuotes",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_SurfaceMaterialId",
                table: "Desks",
                column: "SurfaceMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuotes");

            migrationBuilder.DropTable(
                name: "RushOrderTypes");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "SurfaceMaterials");
        }
    }
}
