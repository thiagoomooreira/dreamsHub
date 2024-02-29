using DreamsHub.Models.Tipos;

namespace DreamsHub.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public ECoresCategoria Cor { get; set; }
}
