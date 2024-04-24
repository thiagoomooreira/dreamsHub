using DreamsHub.Models.Tipos;

namespace DreamsHub.Models.Context;

public class Categoria
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public ECoresCategoria Cor { get; set; }
    public ETipoTransacao Tipo { get; set; }
}
