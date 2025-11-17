using Sismog.Models;
using System.ComponentModel;

namespace Sismog.ViewModels.Orcamento
{
    public class ViewModelOrcamento
    {
        [DisplayName("ID")]
        public long IdOrcamento { get; set; }
        [DisplayName("Número")]
        public long? NumeroOrcamento { get; set; }
        [DisplayName("Cliente")]
        public long IdCliente { get; set; }
        public string NomeCliente { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime? DataCriacao { get; set; }
        public long? Entrega { get; set; }
        public long? Retirada { get; set; }
        [DisplayName("Situação")]
        public long? IdSituacao { get; set; }

        public long? FormaDePagamento { get; set; }

        [DisplayName("Situação")]
        public string Situacao { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
        [DisplayName("Meio de Conhecimento")]
        public long? MeioDeConhecimento { get; set; }
        public long? Quantidade { get; set; }
        public decimal? Desconto { get; set; }
        public ViewModelProdutoOrcamento[] ListaProdutos { get; set; }

        public List<ViewModelVersaoOrcamento> Versoes = [];

        public static explicit operator ViewModelOrcamento(Orcamento v)
        {
            throw new NotImplementedException();
        }
    }
}
