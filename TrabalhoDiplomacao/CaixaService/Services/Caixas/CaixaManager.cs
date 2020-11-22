using CaixaService.Database;
using CaixaService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Services.Caixas
{
    public class CaixaManager : ICaixaManager
    {
        ApplicationDbContext _dbContext;

        public CaixaManager()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Caixa> BuscaTodos()
        {
            return _dbContext.Set<Caixa>().AsNoTracking();
        }

        public Caixa BuscaPorId(int id)
        {
            var caixa = _dbContext.Caixas.Where(x => x.Id == id)
                                         .FirstOrDefault();
            return caixa;
        }
    }
}
