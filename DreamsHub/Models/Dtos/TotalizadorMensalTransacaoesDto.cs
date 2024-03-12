namespace DreamsHub.Models.Dtos;

public class TotalizadorMensalTransacaoesDto
{
    public decimal Receitas { get; set; }
    public decimal Despesas { get; set; }
    public decimal Saldo
    {
        get
        {
            return Receitas - Despesas;
        }
    }
}