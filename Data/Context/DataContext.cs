using Data.DataConfig;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntityCadastrosPessoa>(new Configurations().Configure);
            builder.Entity<EntityContato>(new Configurations().ConfigureContato);         
            base.OnModelCreating(builder);
            
        }
     
    }
}
