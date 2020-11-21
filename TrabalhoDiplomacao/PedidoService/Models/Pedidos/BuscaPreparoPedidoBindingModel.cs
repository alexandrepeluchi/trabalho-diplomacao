using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Pedidos
{
    public class BuscaPreparoPedidoBindingModel
    {
        public long Id { get; set; }
        public float Valor { get; set; }
        public bool Status { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public int MesaId { get; set; }
    }
}
