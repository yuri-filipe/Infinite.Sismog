using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sismog.Models
{
    public partial class Orcamento
    {
        public Orcamento()
        {
            VersaoOrcamentos = new HashSet<VersaoOrcamento>();
        }

        [DisplayName("ID")]
        public long? IdOrcamento { get; set; }
        [DisplayName("Número")]
        public long? NumeroOrcamento { get; set; }
        [DisplayName("Cliente")]
        public long IdCliente { get; set; }
        [DisplayName("Data de Criação")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? DataCriacao { get; set; }
        public long? Entrega { get; set; }
        public long? Retirada { get; set; }
        [DisplayName("Situação")]
        public long? Situacao { get; set; }
        [DisplayName("Observação")]
        public string? Observacao { get; set; }
        [DisplayName("Meio de Conhecimento")]
        public long? MeioDeConhecimento { get; set; }

        public virtual ICollection<VersaoOrcamento> VersaoOrcamentos { get; set; }
    }
}
