namespace Sismog.Models
{
    public partial class ItemPedido
    {
        public long IdItemPedido { get; set; }
        public long Item { get; set; }
        public long IdPedido { get; set; }
        public long Quantidade { get; set; }
        public long? IdLote { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}
