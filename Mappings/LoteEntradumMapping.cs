using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class LoteEntradumMapping : IEntityTypeConfiguration<LoteEntradum>
    {
        public void Configure(EntityTypeBuilder<LoteEntradum> builder)
        {
            _ = builder.ToTable("lote_entrada", "produtos");

            _ = builder.HasKey(x => x.IdLoteEntrada);
            _ = builder.Property(x => x.IdLoteEntrada).HasColumnName("id_lote_entrada");

            _ = builder.Property(x => x.NomeLoteEntrada).HasColumnName("nome_lote_entrada");
            _ = builder.Property(x => x.NumeroLoteEntrada).HasColumnName("numero_lote_entrada");
            _ = builder.Property(x => x.IdEntrada).HasColumnName("id_entrada");
            _ = builder.Property(x => x.Descricao).HasColumnName("descricao");
            _ = builder.Property(x => x.TipoProduto).HasColumnName("tipo_produto");
            _ = builder.Property(x => x.Responsavel).HasColumnName("responsavel");

            _ = builder.HasOne(x => x.IdEntradaNavigation)
                   .WithMany(x => x.LoteEntrada)
                   .HasForeignKey(x => x.IdEntrada);
        }
    }

}
