using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.CreateServico
{
    public class CreateServicoCommand : IRequest<int>
    {
        public int UnidadeTrabralho { get; set; }
        public string Descricao { get;  set; }
    }
}
