using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            _ = builder.ToTable("estoque", "estoques");

            _ = builder.HasKey(x => x.IdEstoque);
            _ = builder.Property(x => x.IdEstoque).HasColumnName("id_estoque");

            _ = builder.Property(x => x.NomeEstoque).HasColumnName("nome_estoque");
            _ = builder.Property(x => x.QtdMinima).HasColumnName("qtd_minima");
            _ = builder.Property(x => x.QtdAtual).HasColumnName("qtd_atual");
            _ = builder.Property(x => x.QtdMaxima).HasColumnName("qtd_maxima");
            _ = builder.Property(x => x.Observacao).HasColumnName("observacao");

            _ = builder.HasMany(x => x.LoteEstoques)
                   .WithOne(x => x.IdEstoqueNavigation)
                   .HasForeignKey(x => x.IdEstoque);

            _ = builder.HasMany(x => x.ProdutoEstoques)
                   .WithOne(x => x.IdEstoqueNavigation)
                   .HasForeignKey(x => x.IdEstoque);
        }
    }
}