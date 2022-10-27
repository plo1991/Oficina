using MediatR;
using Oficinas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.LoginUsuario
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
