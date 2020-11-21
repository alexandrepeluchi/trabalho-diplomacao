using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Produtos
{
    public class CriaProdutoBindingModel
    {
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public float Preco { get; set; }
        public string Codigo { get; set; }
    }
}
