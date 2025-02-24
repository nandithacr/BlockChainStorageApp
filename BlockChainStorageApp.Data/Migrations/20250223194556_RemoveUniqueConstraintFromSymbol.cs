using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChainStorageApp.Data.Migrations
{
    public partial class RemoveUniqueConstraintFromSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIRequestsLog");

            migrationBuilder.DropIndex(
                name: "IX_CryptoData_Symbol",
                table: "CryptoData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIRequestsLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Endpoint = table.Column<string>(type: "TEXT", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResponseTimeMs = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIRequestsLog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptoData_Symbol",
                table: "CryptoData",
                column: "Symbol",
                unique: true);
        }
    }
}
