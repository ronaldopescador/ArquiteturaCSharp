using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Infra.Data;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SigmaContext _dbContext;

        public ProjetoRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Inserir(Projeto entidade)
        {
           await _dbContext.Set<Projeto>().AddAsync(entidade);
           await _dbContext.SaveChangesAsync();
           return true;
        }
    }
}
