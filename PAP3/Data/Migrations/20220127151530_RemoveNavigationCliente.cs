using Microsoft.EntityFrameworkCore.Migrations;

namespace PAP3.Data.Migrations
{
    public partial class RemoveNavigationCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereços_Clientes_ClienteId",
                table: "Endereços");

            migrationBuilder.DropIndex(
                name: "IX_Endereços_ClienteId",
                table: "Endereços");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Endereços");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Endereços",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereços_ClienteId",
                table: "Endereços",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereços_Clientes_ClienteId",
                table: "Endereços",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
