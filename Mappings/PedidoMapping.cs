using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            _ = builder.ToTable("pedido", "pedidos");

            _ = builder.HasKey(x => x.IdPedido);
            _ = builder.Property(x => x.IdPedido).HasColumnName("id_pedido");

            _ = builder.Property(x => x.IdOrcamento).HasColumnName("id_orcamento");
            _ = builder.Property(x => x.IdVersaoOrcamento).HasColumnName("id_versao_orcamento");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");
            _ = builder.Property(x => x.Entrega).HasColumnName("entrega");
            _ = builder.Property(x => x.Retirada).HasColumnName("retirada");
            _ = builder.Property(x => x.ValorProdutos).HasColumnName("valor_produtos");
            _ = builder.Property(x => x.ValorEntrega).HasColumnName("valor_entrega");
            _ = builder.Property(x => x.Desconto).HasColumnName("desconto");
            _ = builder.Property(x => x.Acrescimo).HasColumnName("acrescimo");
            _ = builder.Property(x => x.Subtotal).HasColumnName("subtotal");
            _ = builder.Property(x => x.Total).HasColumnName("total");
            _ = builder.Property(x => x.FormaDePagamento).HasColumnName("forma_de_pagamento");
            _ = builder.Property(x => x.DataCriacao).HasColumnName("data_criacao");
            _ = builder.Property(x => x.Situacao).HasColumnName("situacao");

            _ = builder.HasMany(x => x.ItemPedidos)
                   .WithOne(x => x.IdPedidoNavigation)
                   .HasForeignKey(x => x.IdPedido);
        }
    }

}
