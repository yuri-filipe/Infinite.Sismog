namespace Sismog.Models
{
    public partial class Telegram
    {
        public long IdTelegram { get; set; }
        public string Numero { get; set; } = null!;
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
