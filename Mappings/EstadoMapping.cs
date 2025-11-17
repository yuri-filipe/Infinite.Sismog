using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            _ = builder.ToTable("estado", "cadastro");

            _ = builder.HasKey(x => x.IdEstado);
            _ = builder.Property(x => x.IdEstado).HasColumnName("id_estado");

            _ = builder.Property(x => x.Nome).HasColumnName("nome");
            _ = builder.Property(x => x.Codigo).HasColumnName("codigo");
        }
    }

}
