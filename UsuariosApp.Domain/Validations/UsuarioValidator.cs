using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage("id obrigatorio");

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("nome obrigatório")
                .Length(3, 100)
                .WithMessage("3 a 100 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("email obrigatorio")
                .EmailAddress()
                .WithMessage("email invalido");

            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("senha obrigatoria")
                .Matches((@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$"))
                .WithMessage("seguranca fraca");
        }
    }
}
