using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace CaixaService.Database.Entities
{
    [Table("Caixas")]
    public class Caixa
    {
        public int Id { get; set; }
        public float SaldoInicial { get; set; }
        public float? SaldoFinal { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime? HoraEncerramento { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public bool Status { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
