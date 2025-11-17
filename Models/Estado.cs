namespace Sismog.Models
{
    public partial class Estado
    {
        public long IdEstado { get; set; }
        public string Nome { get; set; } = null!;
        public long? Codigo { get; set; }
    }
}
