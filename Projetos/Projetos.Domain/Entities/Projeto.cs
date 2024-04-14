using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projetos.Domain.Enums;

namespace Projetos.Domain.Entities
{
    public class Projeto
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public StatusEnum Status { get; set; }
    }
}
