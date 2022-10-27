using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficinas.Core.Entities;

namespace Oficinas.Core.Repostories
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task<List<Agendamento>> GetByDateAsync(DateTime dataInicio, DateTime dataFim);
        Task<Agendamento> GetByIdAsync(int id);
        Task<Agendamento> GetByIdServico(int idServico);
        Task<Agendamento> GetByIdOficina(int idOficina);
        Task<bool> VerificaCargaAtingida(int idOficina, int idServico, DateTime dataAgendamento);
        Task AddAsync(Agendamento agendamento);
        Task UpdateAsync(Agendamento agendamento);
        Task DeleteAsync(Agendamento agendamento);
    }
}
