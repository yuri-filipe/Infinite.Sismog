namespace Sismog.ViewModels.Produto
{
    public class ViewModelProdutoOrcamento
    {
        public long IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal? Preco { get; set; }
        public long Quantidade { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Total { get; set; }

    }
}
