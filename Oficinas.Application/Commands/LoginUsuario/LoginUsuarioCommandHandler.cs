using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using Oficinas.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.LoginUsuario
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginUsuarioCommandHandler(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Using algorithm to create a hash password
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);
            // Searching user and hashpassword in DB 
            var usuario = await _usuarioRepository.GetUserByLoginAndPasswordAsync(request.Email, passwordHash);
            // if don't exists, login error
            if (usuario == null)
            {
                return null;
            }
            // if exists, return token 
            var token = _authService.GenerateJwtToken(usuario.Email, usuario.Role);
            return new LoginUsuarioViewModel(usuario.Email, token);
        }
    }
}
