namespace Sismog.Models
{
    public partial class Sms
    {
        public long IdSms { get; set; }
        public string Numero { get; set; } = null!;
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
