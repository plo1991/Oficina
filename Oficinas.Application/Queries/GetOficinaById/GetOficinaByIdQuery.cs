using MediatR;
using Oficinas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetOficinaById
{
    public class GetOficinaByIdQuery : IRequest<OficinaViewModel>
    {
        public GetOficinaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
