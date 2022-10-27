using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery,UsuarioViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            if (usuario == null)
            {
                return null;
            }
            return new UsuarioViewModel(usuario.NomeCompleto,usuario.Email,usuario.DataNascimento,usuario.DataCriacao,usuario.Role);
        }
    }
}
