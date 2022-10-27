using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.UpdateOficina
{
    public class UpdateOficinaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdMaxUnidadeTrabralho { get; set; }
        public string Cnpj { get; set; }
    }
}
