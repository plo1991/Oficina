using MediatR;
using Oficinas.Core.Entities;
using Oficinas.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateServico
{
    public class CreateServicoCommandHandler : IRequestHandler<CreateServicoCommand, int>
    {
        private readonly IServicoRepository _servicoRepository;
        public CreateServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<int> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servico(request.UnidadeTrabralho, request.Descricao);
            await _servicoRepository.AddAsync(servico);
            return servico.Id;
        }
    }
}
