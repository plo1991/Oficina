using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateAgendamento
{
    public class CreateAgendamentoCommand : IRequest<int>
    {
        public int IdOficina { get; set; }
        public int IdServico { get; set; }
        public int IdUsuario{ get; set; }
        public DateTime DataAgendamento { get; set; }
    }
}
