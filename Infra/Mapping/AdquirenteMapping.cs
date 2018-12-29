using Dominio.Aliquota;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class AdquirenteMapping : EntityTypeConfiguration<Adquirente>
    {
        public override void Map(EntityTypeBuilder<Adquirente> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Seed();

            builder.ToTable("Adquirente");
        }
    }
}
