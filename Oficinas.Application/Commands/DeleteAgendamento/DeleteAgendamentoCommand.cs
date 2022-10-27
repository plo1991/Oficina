using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.DeleteAgendamento
{
    public class DeleteAgendamentoCommand : IRequest<Unit>
    {
        public DeleteAgendamentoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
