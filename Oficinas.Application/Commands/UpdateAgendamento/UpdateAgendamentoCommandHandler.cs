using MediatR;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.UpdateAgendamento
{
    public class UpdateAgendamentoCommandHandler : IRequestHandler<UpdateAgendamentoCommand, Unit>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public UpdateAgendamentoCommandHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<Unit> Handle(UpdateAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(request.Id);
            agendamento.Update(request.IdServico, request.DataAgendamento.Date);
            await _agendamentoRepository.UpdateAsync(agendamento);
            return Unit.Value;
        }
    }
}
