using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomsEnglish.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayerContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    USER_PASSWORD = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    PLAYER_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PLAYER_LEVEL = table.Column<int>(type: "int", maxLength: 5, nullable: false, defaultValue: 1),
                    PLAYER_EXPERIENCE = table.Column<int>(type: "int", maxLength: 5, nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYERS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLAYERS_EMAIL",
                table: "PLAYERS",
                column: "USER_EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLAYERS");
        }
    }
}
