using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;

namespace Sigma.Infra.Data.Context
{
    public class SigmaContext : DbContext
    {
        public SigmaContext(DbContextOptions<SigmaContext> options) :  base(options)
        {
            
        }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
