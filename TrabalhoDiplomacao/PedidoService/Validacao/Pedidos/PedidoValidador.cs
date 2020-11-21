using PedidoService.Database.Entities;
using PedidoService.Services.Mesas;
using PedidoService.Services.Preparos;
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
        private readonly IUsuarioManager _usuarioManager;
        private readonly IMesaManager _mesaManager;
        private readonly IProdutoManager _produtoManager;
        private readonly IPreparoManager _preparoManager;

        public PedidoValidador(IUsuarioManager usuarioManager,
                               IMesaManager mesaManager,
                               IProdutoManager produtoManager,
                               IPreparoManager preparoManager)
        {
            _usuarioManager = usuarioManager;
            _mesaManager = mesaManager;
            _produtoManager = produtoManager;
            _preparoManager = preparoManager;
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

            var preparoNoDb = _mesaManager.BuscaPorId(pedido.PreparoId);

            if (preparoNoDb == null)
            {
                throw new Exception("Preparo não foi encontrado.");
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
