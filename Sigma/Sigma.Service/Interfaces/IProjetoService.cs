using Sigma.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Service.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoNovoDto model);
    }
}
