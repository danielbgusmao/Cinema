using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure (EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(300);

            builder.Property(x => x.Email)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(300);

            builder.Property(x => x.Senha)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Senha")
                .HasMaxLength(300);

        }

    }
}
