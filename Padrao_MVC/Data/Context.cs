using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Padrao_MVC.Models;

namespace Padrao_MVC.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Padrao_MVC.Models.Item> Item { get; set; } = default!;
        public DbSet<Padrao_MVC.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}
