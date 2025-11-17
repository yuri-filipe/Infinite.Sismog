using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            _ = builder.ToTable("email", "cadastro");

            _ = builder.HasKey(x => x.IdEmail);
            _ = builder.Property(x => x.IdEmail).HasColumnName("id_email");

            _ = builder.Property(x => x.Endereco).HasColumnName("endereco");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                .WithMany()
                .HasForeignKey(x => x.IdCliente);
        }
    }

}
