using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;

namespace Oficinas.Application.Queries.GetOficinaById
{
    public class GetOficinaByIdQueryHandler : IRequestHandler<GetOficinaByIdQuery, OficinaViewModel>
    {
        private readonly IOficinaRepository _oficinaRepository;
        public GetOficinaByIdQueryHandler(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }

        public async Task<OficinaViewModel> Handle(GetOficinaByIdQuery request, CancellationToken cancellationToken)
        {
            var oficina = await _oficinaRepository.GetByIdAsync(request.Id);
            if (oficina == null) return null;
            var oficinaViewModel = new OficinaViewModel
                (
                oficina.Id,
                oficina.Nome,
                oficina.QtdMaxUnidadeTrabralho,
                oficina.Cnpj
                );
            return oficinaViewModel;
        }
    }
}
