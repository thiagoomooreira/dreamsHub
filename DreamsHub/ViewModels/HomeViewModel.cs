using DreamsHub.Models.Dtos;

namespace DreamsHub.ViewModels;

public class HomeViewModel
{
    public List<TotalizadorCategoriasDto> TotalizadorCategorias { get; set; }
    public string Mes { get; set; }


    // public List<decimal> teste()
    // {
    //     return TotalizadorCategorias.Select(l => l.Total).ToList();
    // }
}