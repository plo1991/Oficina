using FluentValidation;
using Oficinas.Application.Commands.UpdateServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Validators
{
    public class UpdateServicoCommandValidator : AbstractValidator<UpdateServicoCommand>

    {
        public UpdateServicoCommandValidator()
        {
            RuleFor(s => s.UnidadeTrabralho)
               .NotEmpty()
               .NotNull()
               .WithMessage("Unidade de trabalho e obrigatorio");

            RuleFor(s => s.Descricao)
               .NotEmpty()
               .NotNull()
               .WithMessage("Descricao e obrigatorio");
        }
    }
}
