using Microsoft.EntityFrameworkCore;
using Oficinas.Core.Entities;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Infrastructure.Persistence.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly OficinaDbContext _dbContext;
        public ServicoRepository(OficinaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Servico>> GetAllAsync()
        {
            return await _dbContext.Servicos.ToListAsync();
        }

        public async Task<Servico> GetByIdAsync(int id)
        {
            return await _dbContext.Servicos.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Servico servico)
        {
            await _dbContext.Servicos.AddAsync(servico);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Servico servico)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Servico servico)
        {
            _dbContext.Servicos.Remove(servico);
            await _dbContext.SaveChangesAsync();
        }
    }
}
