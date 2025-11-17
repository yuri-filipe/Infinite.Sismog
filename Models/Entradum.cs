namespace Sismog.Models
{
    public class Entradum
    {
        public Entradum()
        {
            LoteEntrada = new HashSet<LoteEntradum>();
            ProdutoEntrada = new HashSet<ProdutoEntradum>();
        }

        public long IdEntrada { get; set; }
        public long NumeroEntrada { get; set; }
        public DateOnly Data { get; set; }
        public long Responsavel { get; set; }

        public virtual ICollection<LoteEntradum> LoteEntrada { get; set; }
        public virtual ICollection<ProdutoEntradum> ProdutoEntrada { get; set; }
    }
}
