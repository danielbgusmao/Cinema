using MediatR;

namespace Cinema.Application.Commands.Sessao
{
    public class CreateSessaoCommand : IRequest<bool>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public float ValorIngresso { get; set; }
        public string TipoAnimacao { get; set; }
        public string TipoAudio { get; set; }
        public Guid FilmeId { get; set; }
        public Guid SalaId { get; set; }

        public CreateSessaoCommand(DateTime dataInicio, DateTime dataFim, float valorIngresso, 
            string tipoAnimacao, string tipoAudio, Guid filmeId, Guid salaId)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorIngresso = valorIngresso;
            TipoAnimacao = tipoAnimacao;
            TipoAudio = tipoAudio;
            FilmeId = filmeId;
            SalaId = salaId;
        }
    }
}
