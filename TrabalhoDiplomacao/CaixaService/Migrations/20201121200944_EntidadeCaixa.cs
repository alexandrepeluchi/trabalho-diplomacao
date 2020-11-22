using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaService.Migrations
{
    public partial class EntidadeCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoInicial = table.Column<float>(nullable: false),
                    SaldoFinal = table.Column<float>(nullable: true),
                    HoraAbertura = table.Column<DateTime>(nullable: false),
                    HoraEncerramento = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caixas");
        }
    }
}
