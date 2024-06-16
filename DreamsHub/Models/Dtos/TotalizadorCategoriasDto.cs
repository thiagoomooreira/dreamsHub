using DreamsHub.Models.Context;

namespace DreamsHub.Models.Dtos;

public class TotalizadorCategoriasDto
{
    public Categoria Categoria { get; set; }
    public decimal Total { get; set; }

    public decimal Media { get; set; }
}