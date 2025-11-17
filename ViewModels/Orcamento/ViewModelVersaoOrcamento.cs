namespace Sismog.ViewModels.Orcamento
{
    public partial class ViewModelVersaoOrcamento
    {
        public long IdVersaoOrcamento { get; set; }
        public long? NumeroVersaoOrcamento { get; set; }
        public string NomeVersaoOrcamento { get; set; } = null!;
        public long? IdOrcamento { get; set; }
        public long? Entrega { get; set; }
        public long? Retirada { get; set; }
        public decimal? ValorItens { get; set; }
        public decimal? ValorEntrega { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Acrescimo { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public long? FormaDePagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public long? IdSituacao { get; set; }
        public string Situacao { get; set; }
        public List<ViewModelItemVersaoOrcamento> Itens = [];

    }
}
