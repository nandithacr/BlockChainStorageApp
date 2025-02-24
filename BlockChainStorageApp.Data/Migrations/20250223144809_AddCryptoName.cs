using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChainStorageApp.Data.Migrations
{
    public partial class AddCryptoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CryptoData",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "MarketCap",
                table: "CryptoData",
                newName: "Previous_Url");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "CryptoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Height",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "High_Fee_Per_Kb",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Last_Fork_Hash",
                table: "CryptoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Last_Fork_Height",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Latest_Url",
                table: "CryptoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Low_Fee_Per_Kb",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Medium_Fee_Per_Kb",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CryptoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Peer_Count",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Previous_Hash",
                table: "CryptoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Unconfirmed_Count",
                table: "CryptoData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "High_Fee_Per_Kb",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Last_Fork_Hash",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Last_Fork_Height",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Latest_Url",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Low_Fee_Per_Kb",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Medium_Fee_Per_Kb",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Peer_Count",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Previous_Hash",
                table: "CryptoData");

            migrationBuilder.DropColumn(
                name: "Unconfirmed_Count",
                table: "CryptoData");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "CryptoData",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Previous_Url",
                table: "CryptoData",
                newName: "MarketCap");
        }
    }
}
