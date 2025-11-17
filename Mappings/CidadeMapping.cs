using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            _ = builder.ToTable("cidade", "cadastro");

            _ = builder.HasKey(x => x.IdCidade);
            _ = builder.Property(x => x.IdCidade).HasColumnName("id_cidade");

            _ = builder.Property(x => x.Nome).HasColumnName("nome");
            _ = builder.Property(x => x.Codigo).HasColumnName("codigo");
        }
    }
}
