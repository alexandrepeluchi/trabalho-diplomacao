using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Services.Roles
{
    public interface IRoleManager
    {
        Role BuscaPorId(int id);
        IEnumerable<Role> BuscaTodos();
    }
}
