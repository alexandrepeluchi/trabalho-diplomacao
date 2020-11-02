using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GW\\SQLEXPRESS; Database=TD; User ID=sa; Password=123qwe;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Role>().HasData(
                new Role { 
                    Id = 1,
                    RoleName = "Admin",
                    Description = "Administradores do sistema"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Gerente",
                    Description = "Gerente do estabelecimento"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Atendente",
                    Description = "Atendente do estabelecimento"
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Garçom",
                    Description = "Garçom do estabelecimento"
                }
            );

            modelbuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Admin",
                    Sobrenome = "Admin",
                    Proprietario = true,
                    Status = true,
                    RoleId = 1,
                    Username = "admin",
                    Password = "admin",
                    DataRegistro = DateTime.Now
                }
            );
        }
    }
}
