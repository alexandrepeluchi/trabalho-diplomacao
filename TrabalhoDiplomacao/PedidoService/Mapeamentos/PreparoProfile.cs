using AutoMapper;
using PedidoService.Database.Entities;
using PedidoService.Models.Pedidos;
using PedidoService.Models.Preparos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Mapeamentos
{
    public class PreparoProfile : Profile
    {
        public PreparoProfile()
        {
            CreateMap<Preparo, BuscaPreparoBindingModel>()
                .ForMember(p => p.Pedidos, opt => opt.Ignore())
                .AfterMap((model, preparo) =>
                {
                    preparo.Pedidos = new List<BuscaPorIdPreparoPedidoBindingModel>();

                    foreach (var pedidos in model.Pedidos)
                    {
                        preparo.Pedidos.Add(new BuscaPorIdPreparoPedidoBindingModel()
                        {
                            Id = (int)pedidos.Id
                        });
                    }
                });

            CreateMap<Preparo, PreparoBindingModel>()
                .ForMember(p => p.Pedidos, opt => opt.Ignore())
                .AfterMap((model, preparo) =>
                {
                    preparo.Pedidos = new List<BuscaPreparoPedidoBindingModel>();

                    foreach (var pedidos in model.Pedidos)
                    {
                        preparo.Pedidos.Add(new BuscaPreparoPedidoBindingModel()
                        {
                            Id = pedidos.Id,
                            Valor = pedidos.Valor,
                            Status = pedidos.Status,
                            DataPedido = pedidos.DataPedido,
                            UsuarioId = pedidos.UsuarioId,
                            MesaId = pedidos.MesaId
                        });
                    }
                });

            CreateMap<CriaPreparoBindingModel, Preparo>();
        }
    }
}
