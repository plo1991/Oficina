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
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly OficinaDbContext _dbContext;
        public AgendamentoRepository(OficinaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _dbContext.Agendamentos
                .Include(a => a.Oficina)
                .Include(a => a.Servico)
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public async Task<Agendamento> GetByIdAsync(int id)
        {
            return await _dbContext.Agendamentos
                .Include(a => a.Oficina)
                .Include(a => a.Servico)
                .Include(a => a.Usuario)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Agendamento> GetByIdServico(int idServico)
        {
            return await _dbContext.Agendamentos.SingleOrDefaultAsync(a => a.IdServico == idServico);
        }

        public async Task<Agendamento> GetByIdOficina(int idOficina)
        {
            return await _dbContext.Agendamentos
                .Include(a => a.Oficina)
                .Include(a => a.Servico)
                .Include(a => a.Usuario)
                .SingleOrDefaultAsync(a => a.IdOficina == idOficina);
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            await _dbContext.Agendamentos.AddAsync(agendamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Agendamento agendamento)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Agendamento agendamento)
        {
            _dbContext.Agendamentos.Remove(agendamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> VerificaCargaAtingida(int idOficina, int idServico, DateTime dataAgendamento)
        {
            var cargaAtual = _dbContext.Agendamentos.Where(a => a.IdOficina == idOficina && a.DataAgendamento == dataAgendamento.Date).Sum(a => a.Servico.UnidadeTrabralho);
            var servicoAtual = await _dbContext.Servicos.SingleOrDefaultAsync(s => s.Id == idServico);
            var oficina = await _dbContext.Oficinas.SingleOrDefaultAsync(o => o.Id == idOficina);
            if ((cargaAtual + servicoAtual.UnidadeTrabralho) > oficina.QtdMaxUnidadeTrabralho)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Agendamento>> GetByDateAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbContext.Agendamentos
                .Include(a => a.Oficina)
                .Include(a => a.Servico)
                .Include(a => a.Usuario)
                .Where(a => a.DataAgendamento >= dataInicio && a.DataAgendamento <= dataFim)
                .ToListAsync();
        }
    }
}
