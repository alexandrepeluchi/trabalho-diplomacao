using PedidoService.Database.Entities;
using PedidoService.Services.Mesas;
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
        private IMesaManager _mesaManager;

        public PedidoValidador(IUsuarioManager usuarioManager,
                               IMesaManager mesaManager)
        {
            _usuarioManager = usuarioManager;
            _mesaManager = mesaManager;
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

            var mesaNoDb = _mesaManager.BuscaPorId(pedido.MesaId);

            if (mesaNoDb == null)
            {
                throw new Exception("A Mesa não foi encontrada.");
            }
        }
    }
}
