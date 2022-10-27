using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Commands.DeleteOficina
{
    public class DeleteOficinaCommand : IRequest<Unit>
    {
        public DeleteOficinaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
