﻿using CaixaService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace CaixaService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<Preparo> Preparos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GW\\SQLEXPRESS; Database=TD; User ID=sa; Password=123qwe;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Role>().HasData(
                new Role
                {
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

            modelbuilder.Entity<Mesa>().HasData(
                new Mesa
                {
                    Id = 1,
                    Numero = 1,
                    Disponivel = true
                },
                new Mesa
                {
                    Id = 2,
                    Numero = 2,
                    Disponivel = true
                },
                new Mesa
                {
                    Id = 3,
                    Numero = 3,
                    Disponivel = true
                },
                new Mesa
                {
                    Id = 4,
                    Numero = 4,
                    Disponivel = true
                },
                new Mesa
                {
                    Id = 5,
                    Numero = 5,
                    Disponivel = true
                }
            );

            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<PedidoProduto>().HasKey(x => new { x.PedidoId, x.ProdutoId });

            modelbuilder.Entity<PedidoProduto>()
                .HasOne(x => x.Pedido)
                .WithMany(mx => mx.PedidoProdutos)
                .HasForeignKey(x => x.PedidoId);

            modelbuilder.Entity<PedidoProduto>()
                .HasOne(x => x.Produto)
                .WithMany(mx => mx.PedidoProdutos)
                .HasForeignKey(x => x.ProdutoId);
        }
    }
}
