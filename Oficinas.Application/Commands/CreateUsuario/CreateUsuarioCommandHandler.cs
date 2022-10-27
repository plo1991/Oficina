using MediatR;
using Oficinas.Core.Entities;
using Oficinas.Core.Repostories;
using Oficinas.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        public CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;

        }
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);
            var usuario = new Usuario(request.NomeCompleto, request.Email, request.DataNascimento, passwordHash, request.Role);
            await _usuarioRepository.AddAsync(usuario);
            return usuario.Id;
        }
    }
}
