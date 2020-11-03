using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;
using UsuarioService.Services;

namespace PedidoService.Validacao
{
    public class PedidoValidador : IPedidoValidador
    {
        private IUsuarioManager _usuarioManager;

        public PedidoValidador(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        public void ValidaRegrasDeNegocio(Pedido pedido)
        {
            VerificaDocumentos(pedido);
        }

        private void VerificaDocumentos(Pedido pedido)
        {
            var usuarioNoDb = _usuarioManager.BuscaPorId(pedido.UsuarioId);

            if (usuarioNoDb == null)
            {
                throw new Exception("O Usuário não foi encontrado.");
            }
        }
    }
}
