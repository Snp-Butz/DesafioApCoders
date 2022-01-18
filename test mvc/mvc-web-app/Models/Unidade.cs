using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_web_app.Models;
[Table("Unidade")]
public class Unidade
{
    [Display(Name = "Identiicação"), Key()]
    public string indentificacao { get; set; }
    [Display(Name = "Proprietário")]
    public string proprietario { get; set; }
    [Display(Name = "Condomínio")]
    public string condominio { get; set; }
    [Display(Name = "Endereço")]
    public string endereco { get; set; }

}
