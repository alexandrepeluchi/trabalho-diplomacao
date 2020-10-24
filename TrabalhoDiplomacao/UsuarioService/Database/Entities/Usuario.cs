﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Database.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Proprietario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }     
        public bool Status { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
