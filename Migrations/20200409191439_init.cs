using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogoITT.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    libro_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    autor = table.Column<string>(nullable: true),
                    edicion = table.Column<string>(nullable: true),
                    editorial = table.Column<string>(nullable: true),
                    isbn = table.Column<string>(nullable: true),
                    paginas = table.Column<string>(nullable: true),
                    clasificacion = table.Column<string>(nullable: true),
                    anio_publicacion = table.Column<string>(nullable: true),
                    registro_en_siabuk = table.Column<string>(nullable: true),
                    reserva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.libro_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
