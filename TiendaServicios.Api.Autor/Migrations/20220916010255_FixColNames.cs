using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class FixColNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiiento",
                table: "AutorLibro",
                newName: "FechaNacimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "AutorLibro",
                newName: "FechaNacimiiento");
        }
    }
}
