using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            _ = builder.ToTable("telefone", "cadastro");

            _ = builder.HasKey(x => x.IdTelefone);
            _ = builder.Property(x => x.IdTelefone).HasColumnName("id_telefone");

            _ = builder.Property(x => x.Numero).HasColumnName("numero");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                   .WithMany()
                   .HasForeignKey(x => x.IdCliente);
        }
    }

}
