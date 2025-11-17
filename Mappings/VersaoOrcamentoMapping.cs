using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class VersaoOrcamentoMapping : IEntityTypeConfiguration<VersaoOrcamento>
    {
        public void Configure(EntityTypeBuilder<VersaoOrcamento> builder)
        {
            _ = builder.ToTable("versao_orcamento", "orcamentos");

            _ = builder.HasKey(x => x.IdVersaoOrcamento);
            _ = builder.Property(x => x.IdVersaoOrcamento).HasColumnName("id_versao_orcamento");

            _ = builder.Property(x => x.NumeroVersaoOrcamento).HasColumnName("numero_versao_orcamento");
            _ = builder.Property(x => x.NomeVersaoOrcamento).HasColumnName("nome_versao_orcamento");
            _ = builder.Property(x => x.IdOrcamento).HasColumnName("id_orcamento");
            _ = builder.Property(x => x.Entrega).HasColumnName("entrega");
            _ = builder.Property(x => x.Retirada).HasColumnName("retirada");
            _ = builder.Property(x => x.ValorItens).HasColumnName("valor_itens");
            _ = builder.Property(x => x.ValorEntrega).HasColumnName("valor_entrega");
            _ = builder.Property(x => x.Desconto).HasColumnName("desconto");
            _ = builder.Property(x => x.Acrescimo).HasColumnName("acrescimo");
            _ = builder.Property(x => x.Subtotal).HasColumnName("subtotal");
            _ = builder.Property(x => x.Total).HasColumnName("total");
            _ = builder.Property(x => x.FormaDePagamento).HasColumnName("forma_de_pagamento");
            _ = builder.Property(x => x.DataCriacao).HasColumnName("data_criacao");
            _ = builder.Property(x => x.Situacao).HasColumnName("situacao");

            _ = builder.HasOne(x => x.IdOrcamentoNavigation)
                   .WithMany(x => x.VersaoOrcamentos)
                   .HasForeignKey(x => x.IdOrcamento);

            _ = builder.HasMany(x => x.ItemVersaoOrcamentos)
                   .WithOne(x => x.IdVersaoOrcamentoNavigation)
                   .HasForeignKey(x => x.IdVersaoOrcamento);
        }
    }

}
