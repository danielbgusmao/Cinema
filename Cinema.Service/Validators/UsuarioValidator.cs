using Cinema.Domain.Entities;
using FluentValidation;

namespace Cinema.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome.")
                .NotNull().WithMessage("Informe o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o e-mail.")
                .NotNull().WithMessage("Informe o e-mail.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Informe a senha.")
                .NotNull().WithMessage("Informe a senha.");
        }
    }
}
