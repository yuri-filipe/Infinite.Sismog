namespace Sismog.Models
{
    public partial class ProdutoEstoque
    {
        public long IdProdutoEstoque { get; set; }
        public long IdProduto { get; set; }
        public long IdEstoque { get; set; }
        public long Quantidade { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; } = null!;
        public virtual Estoque IdEstoqueNavigation { get; set; } = null!;
    }
}
