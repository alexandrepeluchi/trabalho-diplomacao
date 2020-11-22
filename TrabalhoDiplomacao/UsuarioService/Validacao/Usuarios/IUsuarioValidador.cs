using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Validacao.Usuarios
{
    public interface IUsuarioValidador
    {
        void ValidaRegrasDeNegocio(Usuario usuario);
    }
}
