using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database;
using UsuarioService.Database.Entities;

namespace UsuarioService.Services.Roles
{
    public class RoleManager : IRoleManager
    {
        ApplicationDbContext _dbContext;

        public RoleManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Role> BuscaTodos()
        {
            return _dbContext.Set<Role>().AsNoTracking();
        }

        public Role BuscaPorId(int id)
        {
            var role = _dbContext.Roles.Where(x => x.Id == id)
                                        .FirstOrDefault();
            return role;
        }
    }
}
