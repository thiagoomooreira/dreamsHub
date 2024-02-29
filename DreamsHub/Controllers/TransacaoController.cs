using DreamsHub.Dao;
using DreamsHub.Models;
using DreamsHub.Models.Tipos;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class TransacaoController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TransacaoViewModel()
        {
            Transacoes = new TransacaoDao().BuscarTodos()
        });
    }
}