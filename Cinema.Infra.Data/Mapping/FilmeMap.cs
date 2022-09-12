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
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasMaxLength(300);

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("image")
                .HasColumnName("Imagem");

            builder.Property(x => x.Duracao)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Duracao")
                .HasMaxLength(5);

        }

    }
}
