using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioMottu.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliverys_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Deliverys_DeliveryManId",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliverys",
                table: "Deliverys");

            migrationBuilder.RenameTable(
                name: "Deliverys",
                newName: "DeliveryMans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMans",
                table: "DeliveryMans",
                column: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMans_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_DeliveryMans_DeliveryManId",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMans",
                table: "DeliveryMans");

            migrationBuilder.RenameTable(
                name: "DeliveryMans",
                newName: "Deliverys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliverys",
                table: "Deliverys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliverys_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId",
                principalTable: "Deliverys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Deliverys_DeliveryManId",
                table: "Rentals",
                column: "DeliveryManId",
                principalTable: "Deliverys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
