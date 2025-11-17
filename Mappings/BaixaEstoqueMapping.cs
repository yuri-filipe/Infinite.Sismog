using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings;

public class BaixaEstoqueMapping : IEntityTypeConfiguration<BaixaEstoque>
{
    public void Configure(EntityTypeBuilder<BaixaEstoque> builder)
    {
        _ = builder.ToTable("baixa_estoque", "estoques");

        _ = builder.HasKey(x => x.IdBaixaEstoque);

        _ = builder.Property(x => x.IdBaixaEstoque)
            .HasColumnName("id_baixa_estoque");

        _ = builder.Property(x => x.IdProduto)
            .HasColumnName("id_produto")
            .IsRequired();

        _ = builder.Property(x => x.IdEstoque)
            .HasColumnName("id_estoque")
            .IsRequired();

        _ = builder.Property(x => x.IdPedido)
            .HasColumnName("id_pedido")
            .IsRequired();

        _ = builder.Property(x => x.Quantidade)
            .HasColumnName("quantidade")
            .IsRequired();

        _ = builder.Property(x => x.Baixado)
            .HasColumnName("baixado")
            .IsRequired();

        _ = builder.HasOne<Produto>()
            .WithMany()
            .HasForeignKey(x => x.IdProduto)
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasOne<Estoque>()
            .WithMany()
            .HasForeignKey(x => x.IdEstoque)
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasOne<Pedido>()
            .WithMany()
            .HasForeignKey(x => x.IdPedido)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
