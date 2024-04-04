using DreamsHub.Models.Tipos;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class PlanejamentoController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public PlanejamentoController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(new PlanejamentoViewModel()
        {
            Categorias = _categoriaService.BuscarTodos(ETipoTransacao.Despesa)
        });
    }
}