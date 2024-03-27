using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMottu.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMans_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_DeliveryMans_DeliveryManId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Motorcycles_MotorcycleId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_DeliveryManId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_MotorcycleId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryManId",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Rentals",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ActiveRental",
                table: "DeliveryMans",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveRental",
                table: "DeliveryMans");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Rentals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DeliveryManId",
                table: "Rentals",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MotorcycleId",
                table: "Rentals",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMans_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId",
                principalTable: "DeliveryMans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_DeliveryMans_DeliveryManId",
                table: "Rentals",
                column: "DeliveryManId",
                principalTable: "DeliveryMans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Motorcycles_MotorcycleId",
                table: "Rentals",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
