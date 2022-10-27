using FluentValidation;
using Oficinas.Application.Commands.CreateUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Oficinas.Application.Validators
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail incorreto");

            RuleFor(p => p.Senha)
                .Must(ValidaSenha)
                .WithMessage("Senha deve conter 8 caracteres, 1 maiusculo, 1 minusculo and 1 caracter especial");

            RuleFor(p => p.NomeCompleto)
                  .NotEmpty()
                  .NotNull()
                  .WithMessage("Nome não pode ser nulo ou vazio");
        }
        public bool ValidaSenha(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

    }
}
