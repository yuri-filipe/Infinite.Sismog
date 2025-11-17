using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            _ = builder.ToTable("endereco", "cadastro");

            _ = builder.HasKey(x => x.IdEndereco);
            _ = builder.Property(x => x.IdEndereco).HasColumnName("id_endereco");

            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");
            _ = builder.Property(x => x.Logradouro).HasColumnName("logradouro");
            _ = builder.Property(x => x.Cep).HasColumnName("cep");
            _ = builder.Property(x => x.Numero).HasColumnName("numero");
            _ = builder.Property(x => x.Bairro).HasColumnName("bairro");
            _ = builder.Property(x => x.Cidade).HasColumnName("cidade");
            _ = builder.Property(x => x.Estado).HasColumnName("estado");
            _ = builder.Property(x => x.Complemento).HasColumnName("complemento");
            _ = builder.Property(x => x.PontoReferencia).HasColumnName("ponto_referencia");
            _ = builder.Property(x => x.Observacao).HasColumnName("observacao");

            _ = builder.HasOne(x => x.IdClienteNavigation)
                  .WithMany()
                  .HasForeignKey(x => x.IdCliente);
        }
    }

}
