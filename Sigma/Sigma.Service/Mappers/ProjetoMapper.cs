using AutoMapper;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Service.Mappers
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<ProjetoNovoDto, Projeto>();
        }
    }
}


