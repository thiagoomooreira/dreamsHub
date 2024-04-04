using DreamsHub.Models.Dtos;

namespace DreamsHub.Models;

public class FiltroTransacao
{
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }

    public FiltroTransacao()
    {
        DateTime dataAtual = DateTime.Now;
        this.DataInicial = new DateTime(dataAtual.Year, dataAtual.Month, 1);;
        this.DataFinal = new DateTime(
            dataAtual.Year, 
            dataAtual.Month, 
            DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month)
        );
    }

    public FiltroTransacao(FiltroTransacaoDto dto)
    {
        dto.Data = dto.Tipo switch
        {
            "anterior" => dto.Data.AddMonths(-1),
            "proximo" => dto.Data.AddMonths(+1),
            _ => dto.Data
        };

        this.DataInicial = new DateTime(dto.Data.Year, dto.Data.Month, 1);
        this.DataFinal = new DateTime(
            dto.Data.Year, 
            dto.Data.Month, 
            DateTime.DaysInMonth(dto.Data.Year, dto.Data.Month)
        );
    }
}