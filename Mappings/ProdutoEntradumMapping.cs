using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ProdutoEntradumMapping : IEntityTypeConfiguration<ProdutoEntradum>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntradum> builder)
        {
            _ = builder.ToTable("produto_entrada", "produtos");

            _ = builder.HasKey(x => x.IdProdutoEntrada);

            _ = builder.Property(x => x.IdProdutoEntrada).HasColumnName("id_produto_entrada");
            _ = builder.Property(x => x.IdProduto).HasColumnName("id_produto");
            _ = builder.Property(x => x.Quantidade).HasColumnName("quantidade");
            _ = builder.Property(x => x.IdLote).HasColumnName("id_lote");
            _ = builder.Property(x => x.IdEntrada).HasColumnName("id_entrada");

            _ = builder.HasOne(x => x.IdProdutoNavigation)
                   .WithOne(x => x.ProdutoEntradum)
                   .HasForeignKey<ProdutoEntradum>(x => x.IdProduto);

            _ = builder.HasOne(x => x.IdEntradaNavigation)
                   .WithMany(x => x.ProdutoEntrada)
                   .HasForeignKey(x => x.IdEntrada);
        }
    }

}
