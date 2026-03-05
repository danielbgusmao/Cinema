using MediatR;

namespace Cinema.Application.Commands.Usuario
{
    public class CreateUsuarioCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CreateUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
