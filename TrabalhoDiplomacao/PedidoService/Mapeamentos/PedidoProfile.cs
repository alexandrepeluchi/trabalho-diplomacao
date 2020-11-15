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
            CreateMap<Pedido, BuscaPedidoBindingModel>();

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
