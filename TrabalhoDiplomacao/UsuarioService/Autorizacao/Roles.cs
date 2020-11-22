using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Database.Entities
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Gerente = "Gerente";
        public const string Atendente = "Atendente";
        public const string Garcom = "Garçom";

        // Administrador e Gerente
        public const string AdminOuGerente = Admin + "," + Gerente;
    }
}
