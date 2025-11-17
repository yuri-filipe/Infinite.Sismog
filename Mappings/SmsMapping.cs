using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class SmsMapping : IEntityTypeConfiguration<Sms>
    {
        public void Configure(EntityTypeBuilder<Sms> builder)
        {
            _ = builder.ToTable("sms", "cadastro");

            _ = builder.HasKey(x => x.IdSms);
            _ = builder.Property(x => x.IdSms).HasColumnName("id_sms");

            _ = builder.Property(x => x.Numero).HasColumnName("numero");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                   .WithMany()
                   .HasForeignKey(x => x.IdCliente);
        }
    }

}
