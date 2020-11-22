using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Uteis
{
    public interface IUsuarioServico
    {
        Usuario BuscaPorId(int id);
        IQueryable<Usuario> BuscaTodos();
    }
}
