namespace Sismog.Models
{
    public class Estoque
    {
        public long IdEstoque { get; set; }
        public string NomeEstoque { get; set; } = null!;
        public decimal? QtdMinima { get; set; }
        public decimal? QtdAtual { get; set; }
        public decimal? QtdMaxima { get; set; }
        public string? Observacao { get; set; }

        public virtual ICollection<LoteEstoque> LoteEstoques { get; set; }
        public virtual ICollection<ProdutoEstoque> ProdutoEstoques { get; set; }
    }
}
