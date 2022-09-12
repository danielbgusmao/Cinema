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
    public class SalaMap : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Sala");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(300);

            builder.Property(x => x.QuantidadeAssentos)
                .IsRequired()
                .HasColumnName("QuantidadeAssentos")
                .HasMaxLength(5);

        }

    }
}
