namespace Sismog.Models
{
    public partial class LoteEntradum
    {
        public long IdLoteEntrada { get; set; }
        public string? NomeLoteEntrada { get; set; }
        public long NumeroLoteEntrada { get; set; }
        public long IdEntrada { get; set; }
        public string? Descricao { get; set; }
        public long? TipoProduto { get; set; }
        public long Responsavel { get; set; }

        public virtual Entradum IdEntradaNavigation { get; set; } = null!;
    }
}
