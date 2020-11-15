using AutoMapper;
using PedidoService.Database.Entities;
using PedidoService.Models;
using PedidoService.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Mapeamentos
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, BuscaProdutoBindingModel>(); 
            
            CreateMap<CriaProdutoBindingModel, Produto>();
        }
    }
}
