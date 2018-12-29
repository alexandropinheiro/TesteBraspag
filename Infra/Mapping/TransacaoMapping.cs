using Dominio.Operacao;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class TransacaoMapping : EntityTypeConfiguration<Transacao>
    {
        public override void Map(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Valor)
                .IsRequired();

            builder.Property(t => t.Data)
                .IsRequired();

            builder.ToTable("Transacao");
        }
    }
}
