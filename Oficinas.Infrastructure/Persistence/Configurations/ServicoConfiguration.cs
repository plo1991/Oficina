using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficinas.Core.Entities;


namespace Oficinas.Infrastructure.Persistence.Configurations
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
