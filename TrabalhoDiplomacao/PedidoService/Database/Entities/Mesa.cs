using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Database.Entities
{
    [Table("Mesas")]
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool Disponivel { get; set; }
    }
}
