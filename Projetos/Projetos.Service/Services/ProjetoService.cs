using AutoMapper;
using Projetos.Domain.Dtos;
using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Repositories;
using Projetos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetos.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;
        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository)
        {
            this._mapper = mapper;
            this._projetoRepository = projetoRepository;
        }

        public async Task<bool> Inserir(ProjetoNovoDto model)
        {
            return await _projetoRepository.Inserir(_mapper.Map<Projeto>(model));
        }
    }
}
