using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Database.Entities;
using UsuarioService.Models.Usuarios;

namespace UsuarioService.Mapeamentos
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioOutputDTO>();

            CreateMap<CriaUsuarioBindingModel, Usuario>();

            CreateMap<UsuarioBindingModel, Usuario>().ReverseMap();

        }
    }
}
