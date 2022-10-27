using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAgendamentoById
{
    public class GetAgendamentoByIdQueryHandler : IRequestHandler<GetAgendamentoByIdQuery, AgendamentoViewModel>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public GetAgendamentoByIdQueryHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<AgendamentoViewModel> Handle(GetAgendamentoByIdQuery request, CancellationToken cancellationToken)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(request.Id);
            if (agendamento == null) return null;
            var agendamentoViewModel = new AgendamentoViewModel
                (
                agendamento.Id,
                agendamento.IdServico,
                agendamento.Servico.Descricao,
                agendamento.IdOficina,
                agendamento.Oficina.Nome,
                agendamento.IdUsuario,
                agendamento.Usuario.NomeCompleto,
                agendamento.DataAgendamento
                );
            return agendamentoViewModel;
        }
    }
}
