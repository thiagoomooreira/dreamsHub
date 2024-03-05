using DreamsHub.Models.Tipos;

namespace DreamsHub.Models;

public class Transacao
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public Categoria Categoria { get; set; }
    public ETipoTransacao Tipo { get; set; }
    public EStatusTransacao Status { get; set; }

    public Transacao()
    {
        this.Categoria = new Categoria();
    }
}