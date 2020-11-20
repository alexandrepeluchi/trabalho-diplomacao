using AutoMapper;
using PedidoService.Database.Entities;
using PedidoService.Models;
using PedidoService.Models.Pedidos;
using PedidoService.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Mapeamentos
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, BuscaPedidoBindingModel>()
                .AfterMap((model, pedido) =>
                {
                    pedido.Produtos = new List<BuscaPorIdPedidoProdutoBindingModel>();

                    foreach (var produtos in model.PedidoProdutos)
                    {
                        pedido.Produtos.Add(new BuscaPorIdPedidoProdutoBindingModel()
                        {
                            Id = produtos.Produto.Id,
                            Nome = produtos.Produto.Nome,
                            Descricao = produtos.Produto.Descricao,
                            Preco = produtos.Produto.Preco,
                            Codigo = produtos.Produto.Codigo
                        });
                    }
                });

            CreateMap<CriaPedidoBindingModel, Pedido>()
                .ForMember(p => p.PedidoProdutos, opt => opt.Ignore())
                .AfterMap((model, pedido) =>
                {
                    foreach (var produto in model.Produtos)
                    {
                        pedido.PedidoProdutos.Add(new PedidoProduto(0, produto.Id));
                    }
                })
                .ReverseMap();
        }
    }
}
