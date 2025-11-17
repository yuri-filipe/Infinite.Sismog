namespace Sismog.Models
{
    public partial class ItemVersaoOrcamento
    {
        public long IdItemVersaoOrcamento { get; set; }
        public long Item { get; set; }
        public long IdVersaoOrcamento { get; set; }
        public long Quantidade { get; set; }
        public long? IdLote { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public virtual VersaoOrcamento IdVersaoOrcamentoNavigation { get; set; } = null!;
    }
}
