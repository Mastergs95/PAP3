using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Data.Migrations
{
    public partial class ChangeNameProdutoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalhesPedidos_Produtos_ProdutoId",
                table: "DetalhesPedidos");

            migrationBuilder.DropColumn(
                name: "ProdudtoId",
                table: "DetalhesPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "DetalhesPedidos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhesPedidos_Produtos_ProdutoId",
                table: "DetalhesPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalhesPedidos_Produtos_ProdutoId",
                table: "DetalhesPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "DetalhesPedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProdudtoId",
                table: "DetalhesPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhesPedidos_Produtos_ProdutoId",
                table: "DetalhesPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
