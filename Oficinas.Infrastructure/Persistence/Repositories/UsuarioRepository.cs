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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OficinaDbContext _dbContext;
        public UsuarioRepository(OficinaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetUserByLoginAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                               .Usuarios
                               .SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();
        }
    }
}
