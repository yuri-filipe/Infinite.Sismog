namespace Sismog.Models
{
    public partial class Email
    {
        public long IdEmail { get; set; }
        public string Endereco { get; set; } = null!;
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
