using AutoMapper;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Repositories;
using Sigma.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Service.Services
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
