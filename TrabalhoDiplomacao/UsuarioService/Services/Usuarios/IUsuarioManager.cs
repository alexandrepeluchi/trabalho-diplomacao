using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Services
{
    public interface IUsuarioManager
    {
        Usuario Authenticate(string username, string password);
        Usuario BuscaPorId(int id);
        IEnumerable<Usuario> GetAll();
    }
}
