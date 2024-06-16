using System.ComponentModel.DataAnnotations.Schema;

namespace DreamsHub.Models.Context;

public class Planejamento
{
    public int Id { get; set; }
    public DateTime DataReferencia { get; set; }
    public decimal Valor { get; set; }
    public int CategoriaId { get; set; }
    
    [ForeignKey("CategoriaId")]
    public Categoria? Categoria { get; set; }
}