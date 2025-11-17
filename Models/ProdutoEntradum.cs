namespace Sismog.Models
{
    public partial class ProdutoEntradum
    {
        public long IdProdutoEntrada { get; set; }
        public long IdProduto { get; set; }
        public long Quantidade { get; set; }
        public long IdLote { get; set; }
        public long IdEntrada { get; set; }

        public virtual Entradum IdEntradaNavigation { get; set; } = null!;
        public virtual Produto IdProdutoNavigation { get; set; } = null!;
    }
}
