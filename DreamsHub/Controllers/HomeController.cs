using System.Diagnostics;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Models.Tipos;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class HomeController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly ITotalizarTransacoesService _totalizarTransacoesService;
    private readonly ITransacaoService _transacaoService;
    private readonly IMetasService _metasService;

    public HomeController(ITotalizarTransacoesService totalizarTransacoesService, IViewRenderService viewRenderService, ITransacaoService transacaoService, IMetasService metasService)
    {
        _totalizarTransacoesService = totalizarTransacoesService;
        _viewRenderService = viewRenderService;
        _transacaoService = transacaoService;
        _metasService = metasService;
    }

    public IActionResult Index()
    {
        List<TotalizadorCategoriasDto> totalizarCategoriasDoMes = _totalizarTransacoesService.TotalizarCategoriasDoMes(DateTime.Now.Month, DateTime.Now.Year);
        
        
        return View(new HomeViewModel()
        {
            TotalizadorCategorias = totalizarCategoriasDoMes,
            Mes = DateTime.Now.ToString("MMMM"),
            TotalizadorMetas = _metasService.TotalizacaoMetas(),
            TotalReceitas = totalizarCategoriasDoMes.Where(l=>l.Categoria.Tipo == ETipoTransacao.Receita).Sum(l => l.Total),
            TotalDespesas = totalizarCategoriasDoMes.Where(l=>l.Categoria.Tipo == ETipoTransacao.Despesa).Sum(l => l.Total),
        });
    }

    [HttpPost]
    public JsonResult Filtro(string mes, string tipo)
    {
        DateTime data = Tratamentos.ConverterMes(mes);

        data = tipo == "anterior" ? data.AddMonths(-1) : data.AddMonths(1);

        HomeViewModel homeViewModel = new HomeViewModel()
        {
            TotalizadorCategorias = _totalizarTransacoesService.TotalizarCategoriasDoMes(data.Month, data.Year),
            Mes = data.ToString("MMMM")
        };

        return Json(new ViewResponse(_viewRenderService.RenderToString(this, "_dashboardHome", homeViewModel))
        {
            Content = new
            {
                mes = homeViewModel.Mes
            }
        });
    }

    [HttpPost]
    public JsonResult ModalListaTransacao(int categoria, string mes)
    {
        DateTime data = Tratamentos.ConverterMes(mes);

        ListaCategoriaViewModel lista = new()
        {
            Transacoes = _transacaoService.BuscarPorCategoriaPorMes(categoria, data).ToList()
        };
        
        return Json(new ViewResponse(_viewRenderService.RenderToString(this, "_itensPorCategoria", lista)));
    }
}