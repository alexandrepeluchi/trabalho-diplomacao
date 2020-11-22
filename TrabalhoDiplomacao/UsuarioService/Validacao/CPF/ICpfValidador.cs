using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Validacao.CPF
{
    public interface ICpfValidador
    {
        void ValidaCpf(string value, int id = 0);
    }
}
