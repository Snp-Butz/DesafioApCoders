using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_web_app.Models;
[Table("Inquilino")]
public class Inquilino
{
    [Display(Name = "Nome"), Key()]
    public string nome { get; set; }
    [Display(Name = "Idade")]
    public int idade { get; set; }
    [Display(Name = "Sexo"), EnumDataType(typeof(Sexo))]
    public Sexo sexo { get; set; }
    [Display(Name = "Telefone"), Phone()]
    public string telefone { get; set; }
    [Display(Name = "Email"), EmailAddress()]
    public string email { get; set; }

    //public List<Unidade> unidades { get; set; }

}

public enum Sexo
{
    Masculino,
    Feminino
}