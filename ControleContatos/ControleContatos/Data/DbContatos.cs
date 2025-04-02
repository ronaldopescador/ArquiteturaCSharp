using Microsoft.EntityFrameworkCore;

namespace ControleContatos.Data
{
    public class DbContatos : DbContext
    {
        public DbContatos (DbContextOptions<DbContatos> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToLower());
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToLower());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToLower());
                }
            }
        }
        public DbSet<ControleContatos.Models.Contato> Contato { get; set; } = default!;
    }
}
