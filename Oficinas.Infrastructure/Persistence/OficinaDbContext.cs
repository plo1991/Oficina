using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficinas.Core.Entities;
using System.Reflection;

namespace Oficinas.Infrastructure.Persistence
{
    public class OficinaDbContext : DbContext
    {
        public OficinaDbContext(DbContextOptions<OficinaDbContext> options) : base(options)
        {

        }

        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
