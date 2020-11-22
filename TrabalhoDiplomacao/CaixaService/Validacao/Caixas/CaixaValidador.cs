using CaixaService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Services;

namespace CaixaService.Validacao.Caixas
{
    public class CaixaValidador : ICaixaValidador
    {
        private readonly IUsuarioManager _usuarioManager;

        public CaixaValidador(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        public void ValidaRegrasDeNegocio(Caixa caixa)
        {
            VerificaDocumentos(caixa);
        }

        private void VerificaDocumentos(Caixa caixa)
        {
            var usuarioNoDb = _usuarioManager.BuscaPorId(caixa.UsuarioId);

            if (usuarioNoDb == null)
            {
                throw new Exception("O Usuário não foi encontrado.");
            }
        }
    }
}
