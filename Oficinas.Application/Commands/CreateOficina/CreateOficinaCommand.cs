using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateOficina
{
    public class CreateOficinaCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public int QtdMaxUnidadeTrabralho { get; set; }
        public string Cnpj { get; set; }
    }
}
