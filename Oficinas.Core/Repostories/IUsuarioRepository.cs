using Oficinas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Core.Repostories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetUserByLoginAndPasswordAsync(string email, string passwordHash);
        Task AddAsync(Usuario usuario);
    }
}
