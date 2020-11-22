using CaixaService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Services.Caixas
{
    public interface ICaixaManager
    {
        Caixa BuscaPorId(int id);
        IEnumerable<Caixa> BuscaTodos();
    }
}
