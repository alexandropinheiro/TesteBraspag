﻿using Dominio.Taxas;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class TaxaMapping : EntityTypeConfiguration<Taxa>
    {
        public override void Map(EntityTypeBuilder<Taxa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.IdBandeira)
                .IsRequired();

            builder.Property(t => t.IdAdquirente)
                .IsRequired();

            builder.Seed();

            builder.ToTable("Taxa");

            builder.HasOne(a => a.Bandeira)
                .WithMany(b => b.Taxas)
                .HasForeignKey(a => a.IdBandeira);

            builder.HasOne(a => a.Adquirente)
                .WithMany(b => b.Taxas)
                .HasForeignKey(a => a.IdAdquirente);
        }
    }
}
