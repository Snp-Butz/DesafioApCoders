namespace mvc_web_app.Models;

public class DespesasDasUnidades
{
    public string descricao {get;set;}
    public TipoDespesa tipoDespesa {get;set;}
    public float valor {get;set;}
    public DateOnly vencimento_fatura {get;set;}
    public StatusPagamento statusPagamento {get;set;}
}

public enum TipoDespesa
{
    Agua,
    Luz,
    Telefone,
    Condominio,
    TV,
    Internet,
    Reforma
}

public enum StatusPagamento
{
    Pago,
    AguardandoBaixa,
    Extornado,
    Atrazado
}