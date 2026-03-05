using MediatR;

namespace Cinema.Application.Commands.Usuario
{
    public class UpdateUsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public UpdateUsuarioCommand(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
