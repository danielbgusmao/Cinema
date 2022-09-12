using Cinema.Domain.Entities;
using FluentValidation;
using Cinema.Service;
using Cinema.Service.Validators;
using Cinema.Domain.Interfaces;

namespace Cinema.Service.Validators
{
    public  class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(c => c.Duracao)
                .NotEmpty().WithMessage("Imforme a duração.")
                .NotNull().WithMessage("Informe a duração.");

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("Informe o título.")
                .NotNull().WithMessage("Informe o título.");
            
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição.")
                .NotNull().WithMessage("Informe a descrição.");

            RuleFor(c => c.Imagem)
                .NotEmpty().WithMessage("Selecione uma imagem.")
                .NotNull().WithMessage("Selecione uma imagem.");
        }

    }
}
