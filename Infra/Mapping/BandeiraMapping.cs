using Dominio.Bandeiras;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class BandeiraMapping : EntityTypeConfiguration<Bandeira>
    {
        public override void Map(EntityTypeBuilder<Bandeira> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(20)")                
                .IsRequired();

            builder.Seed();

            builder.ToTable("Bandeira");            
        }
    }
}
