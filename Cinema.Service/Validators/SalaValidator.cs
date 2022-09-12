using Cinema.Domain.Entities;
using FluentValidation;

namespace Cinema.Service.Validators
{
    public class SalaValidator : AbstractValidator<Sala>
    {
        public SalaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome.")
                .NotNull().WithMessage("Informe o nome.");

            RuleFor(c => c.QuantidadeAssentos)
                .NotEmpty().WithMessage("Informe a quantidade de assentos.")
                .NotNull().WithMessage("Informe a quantidade de assentos.")
                .GreaterThan(0).WithMessage("Não é possível criar uma sala sem assentos.");
        }
    }
}
