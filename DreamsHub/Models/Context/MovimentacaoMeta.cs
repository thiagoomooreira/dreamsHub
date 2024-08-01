using System.ComponentModel.DataAnnotations.Schema;

namespace DreamsHub.Models.Context;

public class MovimentacaoMeta
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public int MetasId { get; set; }
    
    [ForeignKey("MetasId")]
    public Metas? Meta { get; set; }
}