using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Data.Migrations
{
    public partial class EnderecosRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereços");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodPostal",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Pedidos",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Pedidos",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodPostal",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Funcionarios",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Funcionarios",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodPostal",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Clientes",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Clientes",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UserId",
                table: "Funcionarios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UserId",
                table: "Clientes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_UserId",
                table: "Funcionarios",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_UserId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AspNetUsers_UserId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_UserId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UserId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Endereços",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPostal = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereços", x => x.id);
                });
        }
    }
}
