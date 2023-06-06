using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatingSectionAndRelationWithCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CinemaId",
                table: "Sections",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Cinemas_CinemaId",
                table: "Sections",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Cinemas_CinemaId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CinemaId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Sections");
        }
    }
}
