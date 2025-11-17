namespace Sismog.ViewModels.Orcamento

{
    public class ViewModelItemVersaoOrcamento
    {
        public long IdItemVersaoOrcamento { get; set; }
        public long Item { get; set; }
        public string Nome { get; set; }
        public long IdVersaoOrcamento { get; set; }
        public long Quantidade { get; set; }
        public long IdLote { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
    }
}
