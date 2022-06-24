using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Migrations
{
    public partial class changeCart_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clientes_ClientsId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Produtos_ProdutosId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClientsId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProdutosId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProdutosId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProdutsId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClienteId",
                table: "Cart",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProdutoId",
                table: "Cart",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Produtos_ProdutoId",
                table: "Cart",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Produtos_ProdutoId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClienteId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProdutoId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutosId",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutsId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientsId",
                table: "Cart",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProdutosId",
                table: "Cart",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clientes_ClientsId",
                table: "Cart",
                column: "ClientsId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Produtos_ProdutosId",
                table: "Cart",
                column: "ProdutosId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
