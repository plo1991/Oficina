using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetServicoById
{
    public class GetServicoByIdQueryHandler: IRequestHandler<GetServicoByIdQuery, ServicoViewModel>
    {
        private readonly IServicoRepository _servicoRepository;
        public GetServicoByIdQueryHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<ServicoViewModel> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetByIdAsync(request.Id);
            if (servico == null) return null;
            var servicoViewModel = new ServicoViewModel
                (
                servico.Id,
                servico.UnidadeTrabralho,
                servico.Descricao
                );
            return servicoViewModel;
        }
    }
}
