using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class MeioDeConhecimentoMapping : IEntityTypeConfiguration<MeioDeConhecimento>
    {
        public void Configure(EntityTypeBuilder<MeioDeConhecimento> builder)
        {
            _ = builder.ToTable("meio_de_conhecimento", "cadastro");

            _ = builder.HasKey(x => x.IdMeioDeConhecimento);
            _ = builder.Property(x => x.IdMeioDeConhecimento).HasColumnName("id_meio_de_conhecimento");

            _ = builder.Property(x => x.Motivo).HasColumnName("motivo");
        }
    }

}
