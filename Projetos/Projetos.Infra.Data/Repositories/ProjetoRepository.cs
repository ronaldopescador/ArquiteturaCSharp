using Microsoft.EntityFrameworkCore;
using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetos.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProjetosContext _dbContext;

        public ProjetoRepository(ProjetosContext dbContext)
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
