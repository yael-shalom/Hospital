using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class addWorkerAndWardToPlacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkerId",
                table: "Placements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_WardId",
                table: "Placements",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_WorkerId",
                table: "Placements",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_Wards_WardId",
                table: "Placements",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_Workers_WorkerId",
                table: "Placements",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placements_Wards_WardId",
                table: "Placements");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_Workers_WorkerId",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Placements_WardId",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Placements_WorkerId",
                table: "Placements");

            migrationBuilder.AlterColumn<string>(
                name: "WorkerId",
                table: "Placements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
