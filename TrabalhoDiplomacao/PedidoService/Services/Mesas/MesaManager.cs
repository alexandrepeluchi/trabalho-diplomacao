using Microsoft.EntityFrameworkCore;
using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Mesas
{
    public class MesaManager : IMesaManager
    {
        ApplicationDbContext _dbContext;

        public MesaManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Mesa> BuscaTodos()
        {
            return _dbContext.Set<Mesa>().AsNoTracking();
        }

        public Mesa BuscaPorId(int id)
        {
            var mesa = _dbContext.Mesas.Where(x => x.Id == id)
                                       .FirstOrDefault();
            return mesa;
        }
    }
}
