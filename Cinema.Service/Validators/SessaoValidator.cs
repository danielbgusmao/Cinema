using Cinema.Domain.Entities;
using FluentValidation;
using Cinema.Service;
using Cinema.Service.Validators;
using Cinema.Domain.Interfaces;

namespace Cinema.Service.Validators
{
    public  class SessaoValidator : AbstractValidator<Sessao>
    {
        public SessaoValidator()
        {
            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("Imforme a data de início da sessão.")
                .NotNull().WithMessage("Informe a data de início da sessão.");

            RuleFor(c => c.DataFim)
                .NotEmpty().WithMessage("Imforme a data de término da sessão.")
                .NotNull().WithMessage("Informe a data de término da sessão.");

            RuleFor(c => c.ValorIngresso)
                .NotEmpty().WithMessage("Informe o valor do ingresso.")
                .NotNull().WithMessage("Informe o valor do ingresso.");

            RuleFor(c => c.TipoAnimacao)
                .NotEmpty().WithMessage("Informe o tipo da animação.")
                .NotNull().WithMessage("Informe o tipo da animação.");

            RuleFor(c => c.TipoAudio)
                .NotEmpty().WithMessage("Informe o tipo do áudio.")
                .NotNull().WithMessage("Informe o tipo do áudio.");

        }

    }
}
