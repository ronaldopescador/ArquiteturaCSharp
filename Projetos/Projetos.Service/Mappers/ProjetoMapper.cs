using AutoMapper;
using Projetos.Domain.Dtos;
using Projetos.Domain.Entities;
using Projetos.Domain.Enums;

namespace Projetos.Service.Mappers
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<ProjetoNovoDto, Projeto>();
        }
    }
}


