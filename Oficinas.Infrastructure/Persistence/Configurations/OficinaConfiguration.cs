using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficinas.Core.Entities;

namespace Oficinas.Infrastructure.Persistence.Configurations
{
    public class OficinaConfiguration : IEntityTypeConfiguration<Oficina>
    {
        public void Configure(EntityTypeBuilder<Oficina> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
