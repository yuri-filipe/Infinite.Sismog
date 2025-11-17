using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sismog.Models;

namespace Sismog.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            _ = builder.ToTable("cliente", "cadastro");

            _ = builder.HasKey(x => x.IdCliente);
            _ = builder.Property(x => x.IdCliente).HasColumnName("id_cliente");

            _ = builder.Property(x => x.Nome).HasColumnName("nome");
            _ = builder.Property(x => x.Cpf).HasColumnName("cpf");
            _ = builder.Property(x => x.Rg).HasColumnName("rg");
            _ = builder.Property(x => x.Tipo).HasColumnName("tipo");
            _ = builder.Property(x => x.Nascimento).HasColumnName("nascimento");
            _ = builder.Property(x => x.Idade).HasColumnName("idade");
            _ = builder.Property(x => x.Sexo).HasColumnName("sexo");
            _ = builder.Property(x => x.ClienteDesde).HasColumnName("cliente_desde");
            _ = builder.Property(x => x.ObservacaoCliente).HasColumnName("observacao_cliente");
        }
    }

}
