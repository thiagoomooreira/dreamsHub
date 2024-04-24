using System.Diagnostics;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class HomeController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly ITotalizarTransacoesService _totalizarTransacoesService;
    private readonly ITransacaoService _transacaoService;

    public HomeController(ITotalizarTransacoesService totalizarTransacoesService, IViewRenderService viewRenderService, ITransacaoService transacaoService)
    {
        _totalizarTransacoesService = totalizarTransacoesService;
        _viewRenderService = viewRenderService;
        _transacaoService = transacaoService;
    }

    public IActionResult Index()
    {
        return View(new HomeViewModel()
        {
            TotalizadorCategorias = _totalizarTransacoesService.TotalizarCategoriasDoMes(DateTime.Now.Month, DateTime.Now.Year),
            Mes = DateTime.Now.ToString("MMMM")
        });
    }

    [HttpPost]
    public JsonResult Filtro(string mes, string tipo)
    {
        
        string nomeMes = mes; // Ou qualquer outro mês
        int anoAtual = DateTime.Now.Year;
        
        string dataString = $"01/{GetNumeroMes(nomeMes)}/{anoAtual}";
        DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", null);

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
    public JsonResult ModalListaTransacao(int categoria)
    {
        ListaCategoriaViewModel lista = new ListaCategoriaViewModel()
        {
            Transacoes = _transacaoService.BuscarTodos().Where(l=>l.CategoriaId == categoria).ToList()
        };
        
        return Json(new ViewResponse(_viewRenderService.RenderToString(this, "_itensPorCategoria", lista)));
    }
    
    static string GetNumeroMes(string nomeMes)
    {
        return DateTime.ParseExact(nomeMes, "MMMM", null).ToString("MM");
    }
}