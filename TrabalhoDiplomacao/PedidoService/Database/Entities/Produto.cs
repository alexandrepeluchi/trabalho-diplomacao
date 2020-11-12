using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Database.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Codigo { get; set; }
        public ICollection<PedidoProduto> PedidosProdutos { get; set; }
    }
}
