using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidoService.Migrations
{
    public partial class AlterandoEntidadesERelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos");

            migrationBuilder.DropIndex(
                name: "IX_PedidosProdutos_PedidoId",
                table: "PedidosProdutos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PedidosProdutos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos",
                columns: new[] { "PedidoId", "ProdutoId" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistro",
                value: new DateTime(2020, 11, 15, 14, 44, 35, 543, DateTimeKind.Local).AddTicks(4590));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PedidosProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistro",
                value: new DateTime(2020, 11, 12, 18, 48, 58, 477, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_PedidoId",
                table: "PedidosProdutos",
                column: "PedidoId");
        }
    }
}
