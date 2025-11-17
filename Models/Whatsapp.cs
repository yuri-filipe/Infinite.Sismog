namespace Sismog.Models
{
    public partial class Whatsapp
    {
        public long IdWhatsapp { get; set; }
        public string Numero { get; set; } = null!;
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
