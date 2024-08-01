using DreamsHub.Models.Context;
using DreamsHub.Models.Infra;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Services.Interface;
using DreamsHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Controllers;

public class MetasController : Controller
{
    private readonly IViewRenderService _viewRenderService;
    private readonly IMetasService _metasService;

    public MetasController(IViewRenderService viewRenderService, IMetasService metasService)
    {
        _viewRenderService = viewRenderService;
        _metasService = metasService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Metas> buscarTodos = _metasService.BuscarTodos();
        
        return View(new MetasViewModel()
        {
            Metas = buscarTodos
        });
    }

    [HttpPost]
    public IActionResult Adicionar(int codigo)
    {
        try
        {
            MetasViewModel viewModel = new()
            {
                Movimentacoes = new List<MovimentacaoMeta>()
            };

            if (codigo != 0)
            {
                // viewModel.Transacao = new TransacaoDto(_transacaoService.BuscarPeloCodigo(codigo));
            }

            ViewResponse viewResponse = new ViewResponse(
                this._viewRenderService.RenderToString(this, "_modalAdicionarMeta",
                    viewModel)
            );

            return Json(viewResponse);
        }
        catch (Exception e)
        {
            return Json(new ViewResponse(false, e.Message));
        }
    }
}