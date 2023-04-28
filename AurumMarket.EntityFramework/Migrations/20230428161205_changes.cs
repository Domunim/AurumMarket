using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AurumMarket.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "AssetModel",
                newName: "PricePerKilogram");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "AssetModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Change",
                table: "AssetModel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AssetModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "AssetModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change",
                table: "AssetModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AssetModel");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "AssetModel");

            migrationBuilder.RenameColumn(
                name: "PricePerKilogram",
                table: "AssetModel",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AssetModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
