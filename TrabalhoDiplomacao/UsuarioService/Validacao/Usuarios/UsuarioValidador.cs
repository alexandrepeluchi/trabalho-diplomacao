using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;
using UsuarioService.Services.Roles;

namespace UsuarioService.Validacao.Usuarios
{
    public class UsuarioValidador : IUsuarioValidador
    {
        private readonly IRoleManager _roleManager;

        public UsuarioValidador(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public void ValidaRegrasDeNegocio(Usuario usuario)
        {
            VerificaDocumentos(usuario);
        }

        private void VerificaDocumentos(Usuario usuario)
        {
            var roleNoDb = _roleManager.BuscaPorId(usuario.RoleId);

            if (roleNoDb == null)
            {
                throw new Exception("A Role não foi encontrada.");
            }
        }
    }
}
