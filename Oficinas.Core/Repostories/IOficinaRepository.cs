using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficinas.Core.Entities;

namespace Oficinas.Core.Repostories
{
    public interface IOficinaRepository
    {
        Task<List<Oficina>> GetAllAsync();
        Task<Oficina> GetByIdAsync(int id);
        Task AddAsync(Oficina oficina);
        Task UpdateAsync(Oficina oficina);
        Task DeleteAsync(Oficina oficina);

    }
}
