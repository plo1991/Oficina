using MediatR;
using Oficinas.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public RolesEnum Role { get; set; }
    }
}
