using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database;
using UsuarioService.Database.Entities;

namespace UsuarioService.Uteis
{
    public class UsuarioServico : IUsuarioServico
    {
        protected readonly ApplicationDbContext _dbContext;

        public UsuarioServico()
        {
            _dbContext = new ApplicationDbContext();
        }

        public virtual IQueryable<Usuario> BuscaTodos()
        {
            return _dbContext.Set<Usuario>().AsNoTracking();
        }
    }
}
