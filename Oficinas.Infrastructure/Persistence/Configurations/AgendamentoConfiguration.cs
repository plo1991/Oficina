using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficinas.Core.Entities;

namespace Oficinas.Infrastructure.Persistence.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder
               .HasOne(a => a.Oficina)
               .WithMany(o => o.Agendamentos)
               .HasForeignKey(a => a.IdOficina);

            builder
               .HasOne(a => a.Servico)
               .WithMany(s => s.Agendamentos)
               .HasForeignKey(a => a.IdServico);

            builder
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Agendamentos)
                .HasForeignKey(a => a.IdUsuario);

        }
    }
}