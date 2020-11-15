using PedidoService.Database.Entities;
using PedidoService.Services.Mesas;
using PedidoService.Services.Produtos;
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
        private IProdutoManager _produtoManager;

        public PedidoValidador(IUsuarioManager usuarioManager,
                               IMesaManager mesaManager,
                               IProdutoManager produtoManager)
        {
            _usuarioManager = usuarioManager;
            _mesaManager = mesaManager;
            _produtoManager = produtoManager;
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

            foreach (var produto in pedido.PedidoProdutos)
            {
                var produtoNoDb = _produtoManager.BuscaPorId(produto.ProdutoId);

                if (produtoNoDb == null)
                {
                    throw new Exception("Produto não foi encontrado. (Id = " + produto.ProdutoId + ")");
                }
            }
        }
    }
}
