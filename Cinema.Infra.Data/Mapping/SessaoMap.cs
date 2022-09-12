using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infra.Data.Mapping
{
    public class SessaoMap : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessao");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.DataInicio)
                .IsRequired()
                .HasColumnType("DateTime")
                .HasColumnName("DataInicio");

            builder.Property(x => x.DataFim)
                .IsRequired()
                .HasColumnType("DateTime")
                .HasColumnName("DataFim");

            builder.Property(x => x.ValorIngresso)
                .IsRequired()
                .HasColumnType("float")
                .HasColumnName("ValorIngresso");

            builder.Property(x => x.TipoAnimacao)
                .IsRequired()
                .HasColumnName("TipoAnimacao")
                .HasMaxLength(2);

            builder.Property(x => x.TipoAudio)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("TipoAudio")
                .HasMaxLength(8);

            builder.Property(c => c.Filme)
                .HasColumnName("FilmeId");

            builder.Property(c => c.Sala)
                .HasColumnName("SalaId");
        }
    }
}
