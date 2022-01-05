using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UpravlenskiInformacionniSistemi.Data.Migrations
{
    public partial class addProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductionId",
                table: "Items",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_IsDeleted",
                table: "Production",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Production_ProductionId",
                table: "Items",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Production_ProductionId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProductionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "Items");
        }
    }
}
