using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class OrcamentoMapping : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            _ = builder.ToTable("orcamento", "orcamentos");

            _ = builder.HasKey(x => x.IdOrcamento);
            _ = builder.Property(x => x.IdOrcamento).HasColumnName("id_orcamento");

            _ = builder.Property(x => x.NumeroOrcamento).HasColumnName("numero_orcamento");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");
            _ = builder.Property(x => x.DataCriacao).HasColumnName("data_criacao");
            _ = builder.Property(x => x.Entrega).HasColumnName("entrega");
            _ = builder.Property(x => x.Retirada).HasColumnName("retirada");
            _ = builder.Property(x => x.Situacao).HasColumnName("situacao");
            _ = builder.Property(x => x.Observacao).HasColumnName("observacao");
            _ = builder.Property(x => x.MeioDeConhecimento).HasColumnName("meio_de_conhecimento");

            _ = builder.HasMany(x => x.VersaoOrcamentos)
                   .WithOne(x => x.IdOrcamentoNavigation)
                   .HasForeignKey(x => x.IdOrcamento);
        }
    }

}
