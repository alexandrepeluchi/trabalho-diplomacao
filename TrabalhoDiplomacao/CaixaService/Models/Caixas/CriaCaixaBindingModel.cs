using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Models.Caixas
{
    public class CriaCaixaBindingModel
    {
        public float SaldoInicial { get; set; }
        public DateTime HoraAbertura { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public bool Status { get; set; }
        public int UsuarioId { get; set; }
    }
}
