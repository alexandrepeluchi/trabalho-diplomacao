using PedidoService.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Preparos
{
    public class PreparoBindingModel
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public DateTime DataPreparo { get; set; }
        public bool Status { get; set; }
        public List<BuscaPreparoPedidoBindingModel> Pedidos { get; set; }

        public PreparoBindingModel()
        {
            Pedidos = new List<BuscaPreparoPedidoBindingModel>();
        }
    }
}
