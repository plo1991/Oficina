using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAgendamentoByDate
{
    public class GetAgendamentoByDateQueryHandler : IRequestHandler<GetAgendamentoByDateQuery, List<AgendamentoViewModel>>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public GetAgendamentoByDateQueryHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }
        public async Task<List<AgendamentoViewModel>> Handle(GetAgendamentoByDateQuery request, CancellationToken cancellationToken)
        {
            var agendamentos = await _agendamentoRepository.GetByDateAsync(request.DataInicio, request.DataFim);
            var agendamentoViewModel = agendamentos
                .Select(a => new AgendamentoViewModel(
                    a.Id, a.IdServico, 
                    a.Servico.Descricao, 
                    a.IdOficina, 
                    a.Oficina.Nome,
                    a.IdUsuario,
                    a.Usuario.NomeCompleto,
                    a.DataAgendamento))
                .ToList();
            return agendamentoViewModel;
        }
    }
}
