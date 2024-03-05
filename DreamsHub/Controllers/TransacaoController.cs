using DreamsHub.Dao;
using DreamsHub.Dao.Interface;
using DreamsHub.Models;
using DreamsHub.Models.Dtos;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Models.Tipos;
using DreamsHub.Repository.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class TransacaoController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public TransacaoController(IViewRenderService viewRenderService, ITransacaoRepository transacaoRepository, ICategoriaRepository categoriaRepository)
    {
        _viewRenderService = viewRenderService;
        _transacaoRepository = transacaoRepository;
        _categoriaRepository = categoriaRepository;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TransacaoViewModel()
        {
            Transacoes = _transacaoRepository.BuscarTodos()
        });
    }

    [HttpPost]
    public JsonResult ModalAdicionarTransacao(ETipoTransacao tipo, int codigo = 0)
    {
        ViewResponse viewResponse = new ViewResponse(
            this._viewRenderService.RenderToString(this, "_modalAdicionarTransacao", 
                new AdicionarTransacaoViewModel(tipo)
                {
                    Categorias = _categoriaRepository.BuscarTodos(),
                })
        );

        return Json(viewResponse);
    }

    [HttpPost]
    public IActionResult Salvar(TransacaoDto transacao)
    {
        throw new NotImplementedException();
    }
}