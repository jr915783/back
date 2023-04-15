using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataConfig
{
    public class Configurations : IEntityTypeConfiguration<EntityCadastrosPessoa>
    {
        public void Configure(EntityTypeBuilder<EntityCadastrosPessoa> builder)
        {         
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();           
        }

        public void ConfigureContato(EntityTypeBuilder<EntityContato> builder)
        {        
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email);
            builder.Property(x => x.whatsApp);
            builder.Property(x => x.PessoaId);
            builder.HasOne(x => x.Pessoa);

        }
    }
}
