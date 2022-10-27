using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Oficinas.Core.Entities;
using Oficinas.Core.Repostories;

namespace Oficinas.Application.Commands.CreateAgendamento
{
    public class CreateAgendamentoCommandHandler : IRequestHandler<CreateAgendamentoCommand, int>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public CreateAgendamentoCommandHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<int> Handle(CreateAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var atingido = await _agendamentoRepository
                .VerificaCargaAtingida(request.IdOficina, request.IdServico, request.DataAgendamento);
            if(atingido != false)
            {
                var agendamento = new Agendamento(request.IdOficina, request.IdServico,request.IdUsuario ,request.DataAgendamento.Date);
                await _agendamentoRepository.AddAsync(agendamento);
                return agendamento.Id;
            }
            else {

                return 0;
            }
            
        }
    }
}
