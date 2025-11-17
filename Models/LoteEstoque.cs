namespace Sismog.Models
{
    public partial class LoteEstoque
    {
        public long IdLoteEstoque { get; set; }
        public string? NomeLoteEstoque { get; set; }
        public long NumeroLoteEstoque { get; set; }
        public long IdEstoque { get; set; }
        public string? Descricao { get; set; }
        public long? TipoProduto { get; set; }
        public long Responsavel { get; set; }

        public virtual Estoque IdEstoqueNavigation { get; set; } = null!;
    }
}
