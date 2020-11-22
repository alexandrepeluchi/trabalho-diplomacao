using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Models.Usuarios
{
    public class UsuarioOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
