using Microsoft.EntityFrameworkCore;
using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Produtos
{
    public class ProdutoManager : IProdutoManager
    {
        ApplicationDbContext _dbContext;

        public ProdutoManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Produto> BuscaTodos()
        {
            return _dbContext.Set<Produto>().AsNoTracking();
        }

        public Produto BuscaPorId(int id)
        {
            var produto = _dbContext.Produtos
                                   .Where(x => x.Id == id)
                                   .Include(x => x.PedidoProdutos)
                                   .AsNoTracking()
                                   .FirstOrDefault();
            return produto;
        }

        public Produto Atualiza(Produto produto)
        {
            _dbContext.Produtos.Update(produto);
            _dbContext.SaveChanges();

            return produto;
        }

        public bool Exclui(Produto produto)
        {
            _dbContext.Produtos.Remove(produto);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
