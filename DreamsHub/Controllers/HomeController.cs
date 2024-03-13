using System.Diagnostics;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class HomeController : Controller
{
    private readonly ITotalizarTransacoesService _totalizarTransacoesService;

    public HomeController(ITotalizarTransacoesService totalizarTransacoesService)
    {
        _totalizarTransacoesService = totalizarTransacoesService;
    }

    public IActionResult Index()
    {
        return View(new HomeViewModel()
        {
            TotalizadorCategorias = _totalizarTransacoesService.TotalizarCategoriasDoMes(DateTime.Now.Month, DateTime.Now.Year)
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}