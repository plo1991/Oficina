using MediatR;
using Oficinas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioViewModel>
    {
        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
