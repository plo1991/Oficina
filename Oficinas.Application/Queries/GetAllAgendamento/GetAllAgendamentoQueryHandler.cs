using MediatR;
using Oficinas.Application.Queries.GetAllServico;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAllAgendamento
{
    public class GetAllAgendamentoQueryHandler : IRequestHandler<GetAllAgendamentoQuery, List<AgendamentoViewModel>>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public GetAllAgendamentoQueryHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<List<AgendamentoViewModel>> Handle(GetAllAgendamentoQuery request, CancellationToken cancellationToken)
        {
            var agendamentos = await _agendamentoRepository.GetAllAsync();
            var agendamentoViewModel = agendamentos
                .Select(a => new AgendamentoViewModel(
                    a.Id, 
                    a.IdServico, 
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
