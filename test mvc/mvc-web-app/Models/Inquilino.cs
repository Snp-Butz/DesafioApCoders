namespace mvc_web_app.Models;
public class inquilino
{
    public int id {get;set;}
    public string nome {get;set;}
    public int idade {get;set;}
    public Sexo sexo{get;set;}
    public string telefone{get;set;}
    public string email {get;set;}
}

public enum Sexo
{
    Masculino,
    Feminino
}