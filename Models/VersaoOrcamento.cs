namespace Sismog.Models
{
    public partial class VersaoOrcamento
    {
        public VersaoOrcamento()
        {
            ItemVersaoOrcamentos = new HashSet<ItemVersaoOrcamento>();
        }

        public long? IdVersaoOrcamento { get; set; }
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
        public DateOnly? DataCriacao { get; set; }
        public long? Situacao { get; set; }

        public virtual Orcamento? IdOrcamentoNavigation { get; set; }
        public virtual ICollection<ItemVersaoOrcamento> ItemVersaoOrcamentos { get; set; }
    }
}
