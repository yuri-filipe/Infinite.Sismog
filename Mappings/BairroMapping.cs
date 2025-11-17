using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings;

public class BairroMapping : IEntityTypeConfiguration<Bairro>
{
    public void Configure(EntityTypeBuilder<Bairro> builder)
    {
        _ = builder.ToTable("bairro", "cadastro");

        _ = builder.HasKey(x => x.IdBairro);
        _ = builder.Property(x => x.IdBairro).HasColumnName("id_bairro");

        _ = builder.Property(x => x.Nome).HasColumnName("nome");
        _ = builder.Property(x => x.Codigo).HasColumnName("codigo");
    }
}
