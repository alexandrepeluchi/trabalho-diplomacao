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

        public IEnumerable<Pedido> BuscaTodos()
        {
            return _dbContext.Set<Pedido>().AsNoTracking();
        }

        public Produto BuscaPorId(int id)
        {
            var produto = _dbContext.Produtos
                                   .Where(x => x.Id == id)
                                   .Include(x => x.PedidoProdutos)
                                   .FirstOrDefault();
            return produto;
        }
    }
}
