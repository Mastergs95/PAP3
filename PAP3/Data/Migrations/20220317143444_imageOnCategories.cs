using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Data.Migrations
{
    public partial class imageOnCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Categorias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Categorias");
        }
    }
}
