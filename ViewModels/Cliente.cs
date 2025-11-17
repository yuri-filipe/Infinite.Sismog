using System.ComponentModel.DataAnnotations;

namespace Sismog.ViewModels
{
    public class ViewModelCliente
    {
        public long IdCliente { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Insira um nome !")]
        public string Nome { get; set; } = null!;

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "RG")]
        public string? Rg { get; set; }

        [Display(Name = "Tipo")]
        public long? Tipo { get; set; }

        [Display(Name = "Nascimento")]
        public string? Nascimento { get; set; }
        public long? Idade { get; set; }
        public string? Sexo { get; set; }

        [Display(Name = "Cliente Desde")]
        public string? ClienteDesde { get; set; }

        [Display(Name = "Observação")]
        public string? ObservacaoCliente { get; set; }
        public string? Email { get; set; }
        public string? Sms { get; set; }
        public string? Telefone { get; set; }
        public string? Telegram { get; set; }
        public string? Whatsapp { get; set; }
    }
}
