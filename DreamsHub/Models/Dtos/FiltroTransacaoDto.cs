namespace DreamsHub.Models.Dtos;

public class FiltroTransacaoDto
{
    public DateTime Data { get; set; }
    public string Tipo { get; set; }

    public FiltroTransacaoDto()
    {
        Data = DateTime.Now;
    }
}