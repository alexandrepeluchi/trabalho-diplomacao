using AutoMapper;
using CaixaService.Database.Entities;
using CaixaService.Models.Caixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaService.Mapeamentos
{
    public class CaixaProfile : Profile
    {
        public CaixaProfile()
        {
            CreateMap<Caixa, CaixaOutputDTO>();

            CreateMap<CriaCaixaBindingModel, Caixa>();

            CreateMap<CaixaBindingModel, Caixa>().ReverseMap();
        }
    }
}
