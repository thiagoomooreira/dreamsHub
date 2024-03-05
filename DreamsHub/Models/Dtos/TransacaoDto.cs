namespace DreamsHub.Models.Dtos;

public class TransacaoDto
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public int Categoria { get; set; }
    public string Tipo { get; set; }
    public bool Status { get; set; }

}