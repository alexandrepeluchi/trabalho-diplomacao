using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaService.Migrations
{
    public partial class CriacaoDasTabelasETodasSuasRelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Caixas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                });

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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 450, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Proprietario = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    MesaId = table.Column<int>(nullable: false),
                    PreparoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Preparos_PreparoId",
                        column: x => x.PreparoId,
                        principalTable: "Preparos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    PedidoId = table.Column<long>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => new { x.PedidoId, x.ProdutoId });
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

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Disponivel", "Numero" },
                values: new object[,]
                {
                    { 1, true, 1 },
                    { 2, true, 2 },
                    { 3, true, 3 },
                    { 4, true, 4 },
                    { 5, true, 5 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administradores do sistema", "Admin" },
                    { 2, "Gerente do estabelecimento", "Gerente" },
                    { 3, "Atendente do estabelecimento", "Atendente" },
                    { 4, "Garçom do estabelecimento", "Garçom" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "DataRegistro", "Email", "Nome", "Password", "Proprietario", "RG", "RoleId", "Sobrenome", "Status", "Telefone", "Token", "Username" },
                values: new object[] { 1, null, new DateTime(2020, 11, 21, 17, 53, 27, 446, DateTimeKind.Local).AddTicks(6476), null, "Admin", "admin", true, null, 1, "Admin", true, null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_UsuarioId",
                table: "Caixas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PreparoId",
                table: "Pedidos",
                column: "PreparoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_ProdutoId",
                table: "PedidosProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleId",
                table: "Usuarios",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Usuarios_UsuarioId",
                table: "Caixas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Usuarios_UsuarioId",
                table: "Caixas");

            migrationBuilder.DropTable(
                name: "PedidosProdutos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Preparos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Caixas_UsuarioId",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Caixas");
        }
    }
}
