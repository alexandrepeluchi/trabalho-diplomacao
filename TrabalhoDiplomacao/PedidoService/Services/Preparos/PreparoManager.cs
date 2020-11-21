using Microsoft.EntityFrameworkCore;
using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Preparos
{
    public class PreparoManager : IPreparoManager
    {
        ApplicationDbContext _dbContext;

        public PreparoManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Preparo> BuscaTodos()
        {
           return _dbContext.Set<Preparo>().Include(x => x.Pedidos)
                                           .AsNoTracking();
        }

        public Preparo BuscaPorId(int id)
        {
            var preparo = _dbContext.Preparos
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Pedidos)
                                    .FirstOrDefault();
            return preparo;
        }

    }
}
