using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace PedidoService.Database.Entities
{
    [Table("Pedidos")]
    public class Pedido
    {
        public long Id { get; set; }
        public float Valor { get; set; }
        public bool Status { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int MesaId { get; set; }
        [ForeignKey("MesaId")]
        public Mesa Mesa { get; set; }
        public ICollection<PedidoProduto> PedidosProdutos { get; set; }
    }
}
