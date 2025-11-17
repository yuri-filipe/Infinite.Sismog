using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class LoteEstoqueMapping : IEntityTypeConfiguration<LoteEstoque>
    {
        public void Configure(EntityTypeBuilder<LoteEstoque> builder)
        {
            _ = builder.ToTable("lote_estoque", "produtos");

            _ = builder.HasKey(x => x.IdLoteEstoque);
            _ = builder.Property(x => x.IdLoteEstoque).HasColumnName("id_lote_estoque");

            _ = builder.Property(x => x.NomeLoteEstoque).HasColumnName("nome_lote_estoque");
            _ = builder.Property(x => x.NumeroLoteEstoque).HasColumnName("numero_lote_estoque");
            _ = builder.Property(x => x.IdEstoque).HasColumnName("id_estoque");
            _ = builder.Property(x => x.Descricao).HasColumnName("descricao");
            _ = builder.Property(x => x.TipoProduto).HasColumnName("tipo_produto");
            _ = builder.Property(x => x.Responsavel).HasColumnName("responsavel");

            _ = builder.HasOne(x => x.IdEstoqueNavigation)
                   .WithMany(x => x.LoteEstoques)
                   .HasForeignKey(x => x.IdEstoque);
        }
    }

}
