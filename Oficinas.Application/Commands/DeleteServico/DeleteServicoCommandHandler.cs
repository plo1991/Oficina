using MediatR;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.DeleteServico
{
    public class DeleteServicoCommandHandler : IRequestHandler<DeleteServicoCommand, Unit>
    {
        private readonly IServicoRepository _servicoRepository;

        public DeleteServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }
        public async Task<Unit> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetByIdAsync(request.Id);
            await _servicoRepository.DeleteAsync(servico);
            return Unit.Value;
        }
    }
}
