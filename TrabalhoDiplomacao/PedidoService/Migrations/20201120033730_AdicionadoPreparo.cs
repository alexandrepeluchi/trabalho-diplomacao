using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidoService.Migrations
{
    public partial class AdicionadoPreparo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreparoId",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Preparos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(nullable: true),
                    DataPreparo = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistro",
                value: new DateTime(2020, 11, 20, 0, 37, 29, 993, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PreparoId",
                table: "Pedidos",
                column: "PreparoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Preparos_PreparoId",
                table: "Pedidos",
                column: "PreparoId",
                principalTable: "Preparos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Preparos_PreparoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Preparos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PreparoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PreparoId",
                table: "Pedidos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistro",
                value: new DateTime(2020, 11, 15, 14, 44, 35, 543, DateTimeKind.Local).AddTicks(4590));
        }
    }
}
