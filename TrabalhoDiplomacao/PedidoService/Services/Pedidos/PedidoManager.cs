using Microsoft.EntityFrameworkCore;
using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services
{
    public class PedidoManager : IPedidoManager
    {
        ApplicationDbContext _dbContext;

        public PedidoManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Pedido> BuscaTodos()
        {
            var teste = _dbContext.Set<Pedido>().Include(x => x.PedidoProdutos)
                                                .AsNoTracking();
            return teste;
        }

        public Pedido BuscaPorId(int id)
        {
            var pedido = _dbContext.Pedidos
                                    .Where(x => x.Id == id)
                                    .Include(x => x.PedidoProdutos).ThenInclude(x => x.Produto)
                                    .FirstOrDefault();
            return pedido;
        }
    }
}
