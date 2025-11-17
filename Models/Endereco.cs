namespace Sismog.Models
{
    public partial class Endereco
    {
        public long IdEndereco { get; set; }
        public long IdCliente { get; set; }
        public string Logradouro { get; set; } = null!;
        public string? Cep { get; set; }
        public string? Numero { get; set; }
        public long? Bairro { get; set; }
        public long? Cidade { get; set; }
        public long? Estado { get; set; }
        public string? Complemento { get; set; }
        public string? PontoReferencia { get; set; }
        public string? Observacao { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
