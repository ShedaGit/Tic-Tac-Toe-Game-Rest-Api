using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenseCapitalTestAssignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Board = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextPlayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDraw = table.Column<bool>(type: "bit", nullable: false),
                    IsGameOver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
