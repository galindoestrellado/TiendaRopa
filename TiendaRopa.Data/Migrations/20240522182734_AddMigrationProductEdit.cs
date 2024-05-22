using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaRopa.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationProductEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bodegas",
                table: "Bodegas");

            migrationBuilder.RenameTable(
                name: "Bodegas",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Bodegas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bodegas",
                table: "Bodegas",
                column: "Id");
        }
    }
}
