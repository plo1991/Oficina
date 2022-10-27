using MediatR;
using Oficinas.Core.Repostories;

namespace Oficinas.Application.Commands.UpdateOficina
{
    public class UpdateOficinaCommandHandler : IRequestHandler<UpdateOficinaCommand, Unit>
    {
        private readonly IOficinaRepository _oficinaRepository;
        public UpdateOficinaCommandHandler(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;

        }

        public async Task<Unit> Handle(UpdateOficinaCommand request, CancellationToken cancellationToken)
        {
            var oficina = await _oficinaRepository.GetByIdAsync(request.Id);
            oficina.Update(request.Nome,request.QtdMaxUnidadeTrabralho, request.Cnpj);
            await _oficinaRepository.UpdateAsync(oficina);
            return Unit.Value;
        }
    }
}
