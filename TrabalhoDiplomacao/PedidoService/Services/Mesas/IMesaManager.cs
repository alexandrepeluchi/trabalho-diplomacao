using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Mesas
{
    public interface IMesaManager
    {
        Mesa BuscaPorId(int id);
        IEnumerable<Mesa> BuscaTodos();
    }
}
