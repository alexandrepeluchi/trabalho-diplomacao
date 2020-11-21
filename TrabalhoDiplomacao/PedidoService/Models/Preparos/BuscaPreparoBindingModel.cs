using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Preparos
{
    public class BuscaPreparoBindingModel
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public DateTime DataPreparo { get; set; }
        public bool Status { get; set; }
        public List<BuscaPorIdPreparoPedidoBindingModel> Pedidos { get; set; }

        public BuscaPreparoBindingModel()
        {
            Pedidos = new List<BuscaPorIdPreparoPedidoBindingModel>();
        }
    }
}
