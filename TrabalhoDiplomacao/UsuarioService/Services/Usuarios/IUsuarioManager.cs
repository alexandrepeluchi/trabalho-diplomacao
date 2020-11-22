using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;

namespace UsuarioService.Services
{
    public interface IUsuarioManager
    {
        Usuario Atualiza(Usuario usuario);
        Usuario Authenticate(string username, string password);
        bool BuscaPorCPF(string cpf);
        Usuario BuscaPorId(int id);
        bool BuscaPorUsername(string username);
        IEnumerable<Usuario> GetAll();
    }
}
