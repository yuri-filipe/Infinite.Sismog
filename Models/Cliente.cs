using System.ComponentModel;

namespace Sismog.Models
{
    public partial class Cliente
    {
        [DisplayName("ID")]
        public long? IdCliente { get; set; }
        public string Nome { get; set; } = null!;
        [DisplayName("CPF")]
        public string? Cpf { get; set; }
        [DisplayName("RG")]
        public string? Rg { get; set; }
        public long? Tipo { get; set; }
        public DateTime? Nascimento { get; set; }
        public long? Idade { get; set; }
        public string? Sexo { get; set; }
        [DisplayName("Cliente Desde")]
        public DateTime? ClienteDesde { get; set; }
        [DisplayName("Obervação")]
        public string? ObservacaoCliente { get; set; }

    }
}
