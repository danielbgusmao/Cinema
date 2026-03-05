using MediatR;

namespace Cinema.Application.Commands.Sessao
{
    public class UpdateSessaoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public float ValorIngresso { get; set; }
        public string TipoAnimacao { get; set; }
        public string TipoAudio { get; set; }
        public Guid FilmeId { get; set; }
        public Guid SalaId { get; set; }

        public UpdateSessaoCommand(Guid id, DateTime dataInicio, DateTime dataFim, float valorIngresso,
            string tipoAnimacao, string tipoAudio, Guid filmeId, Guid salaId)
        {
            Id = id;
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
