using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc_web_app.Models;
[Table("Inquilino")]
public class Inquilino
{
    [Display(Name = "CPF / CNPJ"), Key()]
    public string cpfCnpj { get; set; }
    [Display(Name = "Nome")]
    public string nome { get; set; }
    [Display(Name = "Idade")]
    public int idade { get; set; }
    //[Display(Name = "Gênero Sexual")]
    //public string sexo { get; set; }
    [Display(Name = "Telefone"), Phone()]
    public string telefone { get; set; }
    [Display(Name = "Email"), EmailAddress()]
    public string email { get; set; }
    [Display(Name = "Gênero Sexual")]
    public string sexo { get; set; }
}
