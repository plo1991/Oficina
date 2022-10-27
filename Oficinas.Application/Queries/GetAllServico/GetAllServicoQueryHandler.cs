using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAllServico
{
    public class GetAllServicoQueryHandler : IRequestHandler<GetAllServicoQuery, List<ServicoViewModel>>
    {
        private readonly IServicoRepository _servicoRepository;
        public GetAllServicoQueryHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<List<ServicoViewModel>> Handle(GetAllServicoQuery request, CancellationToken cancellationToken)
        {
            var servicos = await _servicoRepository.GetAllAsync();
            var servicoViewModel = servicos
                .Select(o => new ServicoViewModel(o.Id, o.UnidadeTrabralho, o.Descricao))
                .ToList();
            return servicoViewModel;
        }
    }
}
