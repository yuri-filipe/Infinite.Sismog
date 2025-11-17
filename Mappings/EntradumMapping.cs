using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class EntradumMapping : IEntityTypeConfiguration<Entradum>
    {
        public void Configure(EntityTypeBuilder<Entradum> builder)
        {
            _ = builder.ToTable("entrada", "produtos");

            _ = builder.HasKey(x => x.IdEntrada);
            _ = builder.Property(x => x.IdEntrada).HasColumnName("id_entrada");

            _ = builder.Property(x => x.NumeroEntrada).HasColumnName("numero_entrada");
            _ = builder.Property(x => x.Data).HasColumnName("data");
            _ = builder.Property(x => x.Responsavel).HasColumnName("responsavel");

            _ = builder.HasMany(x => x.LoteEntrada)
                   .WithOne(x => x.IdEntradaNavigation)
                   .HasForeignKey(x => x.IdEntrada);

            _ = builder.HasMany(x => x.ProdutoEntrada)
                   .WithOne(x => x.IdEntradaNavigation)
                   .HasForeignKey(x => x.IdEntrada);
        }
    }

}
