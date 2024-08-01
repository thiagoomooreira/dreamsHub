using DreamsHub.Models.Dtos;
using DreamsHub.Models.Tipos;

namespace DreamsHub.ViewModels;

public class HomeViewModel
{
    public List<TotalizadorCategoriasDto> TotalizadorCategorias { get; set; }

    public string Mes { get; set; }
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public List<TotalizacaoMetas> TotalizadorMetas { get; set; }


    public HomeViewModel()
    {
        TotalReceitas = 5430;
        TotalDespesas = 5230;
    }
}