using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class TelegramMapping : IEntityTypeConfiguration<Telegram>
    {
        public void Configure(EntityTypeBuilder<Telegram> builder)
        {
            _ = builder.ToTable("telegram", "cadastro");

            _ = builder.HasKey(x => x.IdTelegram);
            _ = builder.Property(x => x.IdTelegram).HasColumnName("id_telegram");

            _ = builder.Property(x => x.Numero).HasColumnName("numero");
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                   .WithMany()
                   .HasForeignKey(x => x.IdCliente);
        }
    }

}
