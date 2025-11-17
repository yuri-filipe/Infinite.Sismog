namespace Sismog.Models
{
    public partial class Produto
    {
        public long IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public string? Descricao { get; set; }

        public long? Unidades { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoAtacado { get; set; }
        public decimal? PrecoVarejo { get; set; }

        public long? Tipo { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Altura { get; set; }
        public string? Observacao { get; set; }

        public virtual ProdutoEntradum? ProdutoEntradum { get; set; }
        public virtual ICollection<ProdutoEstoque> ProdutoEstoques { get; set; } = [];
    }
}
