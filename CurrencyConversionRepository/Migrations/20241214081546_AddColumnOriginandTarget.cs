using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnOriginandTarget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Currencies",
                newName: "CurrencyTarget");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyOrigin",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                columns: new[] { "DateConversion", "CurrencyOrigin", "CurrencyTarget" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyOrigin",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "CurrencyTarget",
                table: "Currencies",
                newName: "Currency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                columns: new[] { "DateConversion", "Currency" });
        }
    }
}
