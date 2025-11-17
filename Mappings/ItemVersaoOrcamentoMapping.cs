using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ItemVersaoOrcamentoMapping : IEntityTypeConfiguration<ItemVersaoOrcamento>
    {
        public void Configure(EntityTypeBuilder<ItemVersaoOrcamento> builder)
        {
            _ = builder.ToTable("item_versao_orcamento", "orcamentos");

            _ = builder.HasKey(x => x.IdItemVersaoOrcamento);
            _ = builder.Property(x => x.IdItemVersaoOrcamento).HasColumnName("id_item_versao_orcamento");

            _ = builder.Property(x => x.Item).HasColumnName("item");
            _ = builder.Property(x => x.IdVersaoOrcamento).HasColumnName("id_versao_orcamento");
            _ = builder.Property(x => x.Quantidade).HasColumnName("quantidade");
            _ = builder.Property(x => x.IdLote).HasColumnName("id_lote");
            _ = builder.Property(x => x.PrecoUnitario).HasColumnName("preco_unitario");
            _ = builder.Property(x => x.Desconto).HasColumnName("desconto");

            _ = builder.HasOne(x => x.IdVersaoOrcamentoNavigation)
                   .WithMany(x => x.ItemVersaoOrcamentos)
                   .HasForeignKey(x => x.IdVersaoOrcamento);
        }
    }

}
