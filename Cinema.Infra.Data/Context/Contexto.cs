using Cinema.Domain.Entities;
using Cinema.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;



namespace Cinema.Infra.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Filme> Filme { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Sessao> Sessao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }

    }
}
