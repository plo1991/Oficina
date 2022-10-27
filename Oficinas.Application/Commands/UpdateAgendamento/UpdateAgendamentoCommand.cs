using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.UpdateAgendamento
{
    public class UpdateAgendamentoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdServico { get; set; }
        public DateTime DataAgendamento  { get; set; }

    }
}
