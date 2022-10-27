using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.UpdateServico
{
    public class UpdateServicoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UnidadeTrabralho { get; set; }
        public string Descricao { get;  set; }
    }
}
