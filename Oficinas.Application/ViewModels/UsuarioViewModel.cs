using Oficinas.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nomeCompleto, string email, DateTime dataNascimento, DateTime dataCriacao, RolesEnum role)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            DataCriacao = dataCriacao;
            Role = role;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public RolesEnum Role { get; private set; }
    }
}
