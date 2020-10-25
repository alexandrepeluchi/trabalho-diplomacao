using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Uteis
{
    public interface IUsuarioServico
    {
        IQueryable<Usuario> BuscaTodos();
    }
}
