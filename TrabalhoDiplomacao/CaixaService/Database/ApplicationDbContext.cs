using CaixaService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GW\\SQLEXPRESS; Database=TD; User ID=sa; Password=123qwe;");
        }
    }
}
