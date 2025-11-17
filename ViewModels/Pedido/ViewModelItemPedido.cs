namespace Sismog.ViewModels.Pedido
{
    public partial class ViewModelItemPedido
    {
        public long IdItemPedido { get; set; }
        public long Item { get; set; }
        public long IdPedido { get; set; }
        public long Quantidade { get; set; }
        public long IdLote { get; set; }
        public string Nome { get; set; }
        public long IdVersaoOrcamento { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }

    }
}
