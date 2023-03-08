using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebapiCelulares.Migrations
{
    /// <inheritdoc />
    public partial class Pasajeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "marcaid",
                table: "Celulares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celulares_marcaid",
                table: "Celulares",
                column: "marcaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Celulares_Marcas_marcaid",
                table: "Celulares",
                column: "marcaid",
                principalTable: "Marcas",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Celulares_Marcas_marcaid",
                table: "Celulares");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Celulares_marcaid",
                table: "Celulares");

            migrationBuilder.DropColumn(
                name: "marcaid",
                table: "Celulares");
        }
    }
}
