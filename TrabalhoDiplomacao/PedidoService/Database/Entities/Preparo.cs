using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Database.Entities
{
    [Table("Preparos")]
    public class Preparo
    {    
        public int Id { get; set; }
        public string Observacao { get; set; }
        public DateTime DataPreparo { get; set; }
        public bool Status { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }      
    }
}
