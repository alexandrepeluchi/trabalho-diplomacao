using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Database.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        public bool Proprietario { get; set; }
        public bool Status { get; set; }
        public Role Role { get; set; }
        public long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public string Token { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
    }
}
