namespace Sismog.Models
{
    public class BaixaEstoque
    {
        public long IdBaixaEstoque { get; set; }
        public long IdProduto { get; set; }
        public long IdEstoque { get; set; }
        public long IdPedido { get; set; }
        public int Quantidade { get; set; }
        public bool Baixado { get; set; }
    }
}