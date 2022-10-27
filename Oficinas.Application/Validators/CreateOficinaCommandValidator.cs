using FluentValidation;
using Oficinas.Application.Commands.CreateOficina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Oficinas.Application.Validators
{
    public class CreateOficinaCommandValidator : AbstractValidator<CreateOficinaCommand>
    {
        public CreateOficinaCommandValidator()
        {
            RuleFor(o => o.Nome)
               .NotEmpty()
               .NotNull()
               .WithMessage("Nome e obrigatorio");

            RuleFor(o => o.QtdMaxUnidadeTrabralho)
               .NotEmpty()
               .NotNull()
               .WithMessage("Qtd maxima de trabalho e obrigatorio");

            RuleFor(o => o.Cnpj)
               .Must(validaCNPJ)
               .WithMessage("Cnpj invalido");

        }
        public bool validaCNPJ(string cnpj)
        {
            var regex = new Regex(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}");

            return regex.IsMatch(cnpj);
        }
    }
}
