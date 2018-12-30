using Dominio.Operacao;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class ItemTransacaoMapping : EntityTypeConfiguration<ItemTransacao>
    {
        public override void Map(EntityTypeBuilder<ItemTransacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.IdTransacao)
                .IsRequired();

            builder.Property(t => t.IdTaxa)
                .IsRequired();

            builder.Property(t => t.Valor)
                .IsRequired();

            builder.ToTable("ItemTransacao");

            builder.HasOne(it => it.Transacao)
                .WithMany(t => t.Transacoes)
                .HasForeignKey(it => it.IdTransacao);

            builder.HasOne(it => it.Taxa)
                .WithMany(a => a.Transacoes)
                .HasForeignKey(it => it.IdTaxa);

        }
    }
}
