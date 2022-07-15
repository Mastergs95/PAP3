using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Migrations
{
    public partial class addDescri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Produtos",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Produtos");
        }
    }
}
