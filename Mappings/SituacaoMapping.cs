using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class SituacaoMapping : IEntityTypeConfiguration<Situacao>
    {
        public void Configure(EntityTypeBuilder<Situacao> builder)
        {
            _ = builder.ToTable("situacao", "info");

            _ = builder.HasKey(x => x.IdSituacao);
            _ = builder.Property(x => x.IdSituacao).HasColumnName("id_situacao");

            _ = builder.Property(x => x.Nome).HasColumnName("nome");
        }
    }

}
