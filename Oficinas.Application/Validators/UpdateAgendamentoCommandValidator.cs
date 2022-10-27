using FluentValidation;
using Oficinas.Application.Commands.UpdateAgendamento;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.Validators
{
    public class UpdateAgendamentoCommandValidator : AbstractValidator<UpdateAgendamentoCommand>
    {
        public UpdateAgendamentoCommandValidator()
        {

        RuleFor(a => a.IdServico)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id do servico e obrigatorio!");


        RuleFor(a => a.DataAgendamento)
                .NotEmpty()
                .NotNull()
                .WithMessage("data do agendamento e obrigatoria!");

            RuleFor(a => a.DataAgendamento)
                      .Must(validaDiaUtil)
                      .WithMessage("Não é possivel agendar serviços para o final de semana!");
        }
        public bool validaDiaUtil(DateTime dataAgendamento)
        {
            var dia = dataAgendamento.ToString("dddd", new CultureInfo("pt-BR"));
            if (dia == "sábado" || dia == "domingo")
            {
                return false;
            }
            return true;
        }
    }
}
