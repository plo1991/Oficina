using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficinas.Core.Entities;

namespace Oficinas.Core.Repostories
{
    public interface IServicoRepository
    {
        Task<List<Servico>> GetAllAsync();
        Task<Servico> GetByIdAsync(int id);
        Task AddAsync(Servico servico);
        Task UpdateAsync(Servico servico);
        Task DeleteAsync(Servico servico);


    }
}
