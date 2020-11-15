using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Produtos
{
    public interface IProdutoManager
    {
        Produto BuscaPorId(int id);
        IEnumerable<Pedido> BuscaTodos();
    }
}
