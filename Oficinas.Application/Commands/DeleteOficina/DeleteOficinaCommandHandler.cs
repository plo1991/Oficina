using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Oficinas.Core.Repostories;

namespace Oficinas.Application.Commands.DeleteOficina
{
    public class DeleteOficinaCommandHandler : IRequestHandler<DeleteOficinaCommand,Unit>
    {
        private readonly IOficinaRepository _oficinaRepository;

        public DeleteOficinaCommandHandler(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }

        public async Task<Unit> Handle(DeleteOficinaCommand request, CancellationToken cancellationToken)
        {
            var oficina = await _oficinaRepository.GetByIdAsync(request.Id);
            await _oficinaRepository.DeleteAsync(oficina);
            return Unit.Value;

        }
    }
}
