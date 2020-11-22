using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Models.Caixas
{
    public class CaixaOutputDTO
    {
        public int Id { get; set; }
        public float SaldoInicial { get; set; }
        public float? SaldoFinal { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime? HoraEncerramento { get; set; }
        public bool Status { get; set; }
        public int UsuarioId { get; set; }
    }
}
