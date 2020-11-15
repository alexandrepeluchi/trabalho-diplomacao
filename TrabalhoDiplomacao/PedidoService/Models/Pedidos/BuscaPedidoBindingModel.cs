using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models
{
    public class BuscaPedidoBindingModel
    {
        public long Id { get; set; }
        public float Valor { get; set; }
        public bool Status { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public int MesaId { get; set; }
        public List<BuscaProdutoBindingModel> Produtos { get; set; }

        public BuscaPedidoBindingModel()
        {
            Produtos = new List<BuscaProdutoBindingModel>();
        }
    }
}
