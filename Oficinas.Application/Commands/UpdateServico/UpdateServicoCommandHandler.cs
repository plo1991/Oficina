using MediatR;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.UpdateServico
{
    public class UpdateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, Unit>
    {
        private readonly IServicoRepository _servicoRepository;
        public UpdateServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<Unit> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetByIdAsync(request.Id);
            servico.Update(request.UnidadeTrabralho, request.Descricao);
            await _servicoRepository.UpdateAsync(servico);
            return Unit.Value;
        }
    }
}
