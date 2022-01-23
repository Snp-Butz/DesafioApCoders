using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc_web_app.Models
{
    [Table("DespesasDasUnidades")]
    public class DespesaDaUnidade
    {
        [Key()]
        public int id { get; set; }
        [Display(Name = "Descrição"), Required()]
        public string descricao { get; set; }
        [Display(Name = "Tipo de despesa"), Required()]
        public string tipoDespesa { get; set; }
        [Display(Name = "Valor"), Required()]
        public float valor { get; set; }
        [Display(Name = "Data  de vencimento"), Required(), DataType(DataType.Date)]
        public DateTime vencimento_fatura { get; set; }
        [Display(Name = "Status do pagamento"), Required()]
        public string statusPagamento { get; set; }
        [Display(Name = "Unidade"), Required()]
        public string unidadeId { get; set; }

    }
}
