using MediatR;
using Oficinas.Core.Entities;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateOficina
{
    public class CreateOficinaCommandHandler : IRequestHandler<CreateOficinaCommand, int>
    {
        private readonly IOficinaRepository _oficinaRepository;

        public CreateOficinaCommandHandler(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }
        public async Task<int> Handle(CreateOficinaCommand request, CancellationToken cancellationToken)
        {
            var oficina = new Oficina(request.Nome, request.QtdMaxUnidadeTrabralho, request.Cnpj);
            await _oficinaRepository.AddAsync(oficina);
            return oficina.Id;
        }
    }
}
