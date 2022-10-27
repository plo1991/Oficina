using MediatR;
using Oficinas.Application.ViewModels;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAllOficinas
{
    public class GetAllOficinasQueryHandler : IRequestHandler<GetAllOficinasQuery, List<OficinaViewModel>>
    {
        private readonly IOficinaRepository _oficinaRepository;
        public GetAllOficinasQueryHandler(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }

        public async Task<List<OficinaViewModel>> Handle(GetAllOficinasQuery request, CancellationToken cancellationToken)
        {
            var oficinas = await _oficinaRepository.GetAllAsync();
            var oficinaViewModel = oficinas
                .Select(o => new OficinaViewModel(o.Id, o.Nome, o.QtdMaxUnidadeTrabralho, o.Cnpj))
                .ToList();
            return oficinaViewModel;
        }
    }
}
