using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidoService.Migrations
{
    public partial class RelacaoDeProdutoComPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<float>(nullable: false),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<long>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_ProdutoId",
                table: "PedidosProdutos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistro",
                value: new DateTime(2020, 11, 2, 21, 31, 59, 993, DateTimeKind.Local).AddTicks(3896));
        }
    }
}
