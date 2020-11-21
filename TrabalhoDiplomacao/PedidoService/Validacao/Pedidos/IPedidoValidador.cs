using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Validacao
{
    public interface IPedidoValidador
    {
        void ValidaRegrasDeNegocio(Pedido pedido);
    }
}
