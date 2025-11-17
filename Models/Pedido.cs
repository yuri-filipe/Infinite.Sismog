namespace Sismog.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItemPedidos = new HashSet<ItemPedido>();
        }

        public long IdPedido { get; set; }
        public long IdOrcamento { get; set; }
        public long IdVersaoOrcamento { get; set; }
        public long IdCliente { get; set; }
        public long? Entrega { get; set; }
        public long? Retirada { get; set; }
        public decimal? ValorProdutos { get; set; }
        public decimal? ValorEntrega { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Acrescimo { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public long? FormaDePagamento { get; set; }
        public DateOnly? DataCriacao { get; set; }
        public long? Situacao { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
