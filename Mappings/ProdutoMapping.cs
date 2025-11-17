using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            _ = builder.ToTable("produto", "produtos");

            _ = builder.HasKey(x => x.IdProduto);
            _ = builder.Property(x => x.IdProduto)
                .HasColumnName("id_produto");

            _ = builder.Property(x => x.NomeProduto)
                .HasColumnName("nome_produto");

            _ = builder.Property(x => x.Descricao)
                .HasColumnName("descricao");

            _ = builder.Property(x => x.Unidades)
                .HasColumnName("unidades");

            _ = builder.Property(x => x.PrecoCusto)
                .HasColumnName("preco_custo");

            _ = builder.Property(x => x.PrecoAtacado)
                .HasColumnName("preco_atacado");

            _ = builder.Property(x => x.PrecoVarejo)
                .HasColumnName("preco_varejo");

            _ = builder.Property(x => x.Tipo)
                .HasColumnName("tipo");

            _ = builder.Property(x => x.Peso)
                .HasColumnName("peso");

            _ = builder.Property(x => x.Altura)
                .HasColumnName("altura");

            _ = builder.Property(x => x.Observacao)
                .HasColumnName("observacao");

            _ = builder.HasMany(x => x.ProdutoEstoques)
                .WithOne(x => x.IdProdutoNavigation)
                .HasForeignKey(x => x.IdProduto);
        }
    }
}
