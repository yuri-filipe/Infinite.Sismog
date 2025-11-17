using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class WhatsappMapping : IEntityTypeConfiguration<Whatsapp>
    {
        public void Configure(EntityTypeBuilder<Whatsapp> builder)
        {
            _ = builder.ToTable("whatsapp", "cadastro");

            _ = builder.HasKey(x => x.IdWhatsapp);
            _ = builder.Property(x => x.IdWhatsapp).HasColumnName("id_whatsapp");

            _ = builder.Property(x => x.Numero).HasColumnName("numero");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                   .WithMany()
                   .HasForeignKey(x => x.IdCliente);
        }
    }

}
