using MediatR;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.DeleteAgendamento
{
    public class DeleteAgendamentoCommandHandler : IRequestHandler<DeleteAgendamentoCommand, Unit>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public DeleteAgendamentoCommandHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<Unit> Handle(DeleteAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(request.Id);
            await _agendamentoRepository.DeleteAsync(agendamento);
            return Unit.Value;
        }
    }
}
