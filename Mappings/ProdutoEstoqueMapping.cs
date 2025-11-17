using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ProdutoEstoqueMapping : IEntityTypeConfiguration<ProdutoEstoque>
    {
        public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
        {
            _ = builder.ToTable("produto_estoque", "produtos");

            _ = builder.HasKey(x => x.IdProdutoEstoque);
            _ = builder.Property(x => x.IdProdutoEstoque)
                .HasColumnName("id_produto_estoque");

            _ = builder.Property(x => x.IdProduto)
                .HasColumnName("id_produto");

            _ = builder.Property(x => x.IdEstoque)
                .HasColumnName("id_estoque");

            _ = builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade");

            _ = builder.HasOne(x => x.IdProdutoNavigation)
                .WithMany(x => x.ProdutoEstoques)
                .HasForeignKey(x => x.IdProduto);

            _ = builder.HasOne(x => x.IdEstoqueNavigation)
                .WithMany(x => x.ProdutoEstoques)
                .HasForeignKey(x => x.IdEstoque);
        }
    }
}
