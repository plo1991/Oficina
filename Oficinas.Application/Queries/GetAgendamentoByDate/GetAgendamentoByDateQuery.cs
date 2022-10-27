using MediatR;
using Oficinas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAgendamentoByDate
{
    public class GetAgendamentoByDateQuery : IRequest<List<AgendamentoViewModel>>
    {
        public GetAgendamentoByDateQuery(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
