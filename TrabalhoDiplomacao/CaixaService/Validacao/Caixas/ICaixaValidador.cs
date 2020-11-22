using CaixaService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Validacao.Caixas
{
    public interface ICaixaValidador
    {
        void ValidaRegrasDeNegocio(Caixa caixa);
    }
}
