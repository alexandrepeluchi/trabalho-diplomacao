using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Produtos
{
    public class BuscaPorIdPedidoProdutoBindingModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Codigo { get; set; }
    }
}
