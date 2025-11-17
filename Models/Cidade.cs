namespace Sismog.Models
{
    public partial class Cidade
    {
        public long IdCidade { get; set; }
        public string Nome { get; set; } = null!;
        public long? Codigo { get; set; }
    }
}
