using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            _ = builder.ToTable("item_pedido", "pedidos");

            _ = builder.HasKey(x => x.IdItemPedido);

            _ = builder.Property(x => x.IdItemPedido).HasColumnName("id_item_pedido");
            _ = builder.Property(x => x.Item).HasColumnName("item");
            _ = builder.Property(x => x.IdPedido).HasColumnName("id_pedido");
            _ = builder.Property(x => x.Quantidade).HasColumnName("quantidade");
            _ = builder.Property(x => x.IdLote).HasColumnName("id_lote");
            _ = builder.Property(x => x.PrecoUnitario).HasColumnName("preco_unitario");
            _ = builder.Property(x => x.Desconto).HasColumnName("desconto");

            _ = builder.HasOne(x => x.IdPedidoNavigation)
                   .WithMany(x => x.ItemPedidos)
                   .HasForeignKey(x => x.IdPedido);
        }
    }

}
