using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;
using UsuarioService.Services;
using UsuarioService.Services.Roles;
using UsuarioService.Validacao.CPF;

namespace UsuarioService.Validacao.Usuarios
{
    public class UsuarioValidador : IUsuarioValidador
    {
        private readonly IRoleManager _roleManager;
        private readonly IUsuarioManager _usuarioManager;
        private readonly ICpfValidador _cpfValidador;

        public UsuarioValidador(IRoleManager roleManager,
                                IUsuarioManager usuarioManager,
                                ICpfValidador cpfValidador)
        {
            _roleManager = roleManager;
            _usuarioManager = usuarioManager;
            _cpfValidador = cpfValidador;
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

            var usuarioUsername = _usuarioManager.BuscaPorUsername(usuario.Username);

            if (usuarioUsername)
            {
                throw new Exception("Já existe um Usuário com o 'Username' informado.");
            }

            if (usuario.Id != 0)
            {
                _cpfValidador.ValidaCpf(usuario.CPF, usuario.Id);
            }
            else
            {
                _cpfValidador.ValidaCpf(usuario.CPF);
            }
            
        }
    }
}
