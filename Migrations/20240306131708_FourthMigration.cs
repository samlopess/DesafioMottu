using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMottu.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorcycleAvailable",
                table: "Motorcycles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotorcycleAvailable",
                table: "Motorcycles");
        }
    }
}
