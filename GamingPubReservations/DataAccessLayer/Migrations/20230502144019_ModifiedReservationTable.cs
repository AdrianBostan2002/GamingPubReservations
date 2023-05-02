using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_GamingPubs_GamingPubId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GamingPubId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GamingPubId",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamingPubId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GamingPubId",
                table: "Reservations",
                column: "GamingPubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_GamingPubs_GamingPubId",
                table: "Reservations",
                column: "GamingPubId",
                principalTable: "GamingPubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
