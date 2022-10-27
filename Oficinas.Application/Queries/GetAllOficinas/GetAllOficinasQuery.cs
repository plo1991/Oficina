using MediatR;
using Oficinas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetAllOficinas
{
    public class GetAllOficinasQuery : IRequest<List<OficinaViewModel>>
    {
    }
}
