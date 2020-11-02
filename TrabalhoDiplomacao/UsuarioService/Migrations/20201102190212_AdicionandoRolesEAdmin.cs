using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioService.Migrations
{
    public partial class AdicionandoRolesEAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { 1, null, new DateTime(2020, 11, 2, 16, 2, 11, 818, DateTimeKind.Local).AddTicks(898), null, "Admin", "admin", true, null, 1, "Admin", true, null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleId",
                table: "Usuarios",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
